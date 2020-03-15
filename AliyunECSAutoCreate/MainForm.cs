using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Ecs.Model.V20140526;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace AliyunECSAutoCreate
{
    public partial class MainForm : Form
    {
        private string accessKeyId = null;
        private string accessSecret = null;
        private string regionId = null;
        private string instanceName = null;
        private string launchTemplateName = null;
        private string domainRecordId = null;
        private string domainRecordRR = null;

        private bool hasDomain = false;
        private string instanceId = null;
        private int checkCount = 0;
        private DefaultAcsClient client = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BackgroundWork(() =>
            {
                accessKeyId = ConfigurationManager.AppSettings["AccessKeyId"];
                accessSecret = ConfigurationManager.AppSettings["AccessSecret"];
                regionId = ConfigurationManager.AppSettings["RegionId"];
                instanceName = ConfigurationManager.AppSettings["InstanceName"];
                launchTemplateName = ConfigurationManager.AppSettings["LaunchTemplateName"];
                domainRecordId = ConfigurationManager.AppSettings["DomainRecordId"];
                domainRecordRR = ConfigurationManager.AppSettings["DomainRecordRR"];

                if (!string.IsNullOrEmpty(domainRecordId))
                {
                    hasDomain = true;
                }

                DefaultProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessSecret);
                client = new DefaultAcsClient(profile);

                CheckInstances();
            });
        }


        void CheckInstances(bool loop = false)
        {
            var request = new DescribeInstancesRequest
            {
                RegionId = regionId,
                InstanceName = instanceName
            };
            var response = client.GetAcsResponse(request);
            var instance = response.Instances.FirstOrDefault();
            if (instance != null && instance.PublicIpAddress.Any())
            {
                checkCount = 0;
                instanceId = instance.InstanceId;
                InvokeVoid(() =>
                {
                    tb1.Text = instance.PublicIpAddress.FirstOrDefault();
                    btn1.Text = "释放";
                    btn1.Enabled = true;
                    if (hasDomain) btn2.Enabled = true;
                });
            }
            else
            {
                if (loop)
                {
                    if (checkCount >= 10)
                    {
                        throw new Exception("未查询到服务器！");
                    }
                    else
                    {
                        checkCount++;
                        StartTimer();
                    }
                }
                else
                {
                    InvokeVoid(() =>
                    {
                        tb1.Text = "";
                        btn1.Text = "创建";
                        btn1.Enabled = true;
                        btn2.Enabled = false;
                    });
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Enabled = false;
            btn2.Enabled = false;

            BackgroundWork(() =>
            {
                if (string.IsNullOrEmpty(instanceId))
                {
                    var request = new RunInstancesRequest
                    {
                        RegionId = regionId,
                        LaunchTemplateName = launchTemplateName,
                        InstanceChargeType = "PostPaid"
                    };
                    var response = client.GetAcsResponse(request);
                    if (!response.InstanceIdSets.Any())
                    {
                        throw new Exception("创建失败！");
                    }

                    StartTimer();
                }
                else
                {
                    var request = new DeleteInstanceRequest
                    {
                        RegionId = regionId,
                        InstanceId = instanceId,
                        Force = true
                    };
                    client.GetAcsResponse(request);
                    instanceId = null;
                    CheckInstances();
                }
            });
        }

        void BackgroundWork(Action action)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (a, b) =>
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception ex)
                {
                    InvokeVoid(() =>
                    {
                        tb1.Text = ex.Message;
                        if (ex.Message.StartsWith("IncorrectInstanceStatus.Initializing"))
                        {
                            btn1.Enabled = true;
                            btn2.Enabled = false;
                        }
                    });
                }
            };
            bw.RunWorkerAsync();
        }

        void InvokeVoid(Action action)
        {
            this.Invoke(action);
        }

        private void tm1_Tick(object sender, EventArgs e)
        {
            tm1.Stop();
            CheckInstances(true);
        }

        void StartTimer()
        {
            InvokeVoid(() =>
            {
                tm1.Start();
            });
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            var ip = tb1.Text.Trim();
            if (!string.IsNullOrEmpty(ip) && ip.Length < 16 && ip.Length > 6)
            {
                btn2.Enabled = false;

                BackgroundWork(() =>
                {
                    var request = new UpdateDomainRecordRequest
                    {
                        RR = domainRecordRR,
                        RecordId = domainRecordId,
                        Type = "A",
                        _Value = ip
                    };
                    client.GetAcsResponse(request);
                    InvokeVoid(() =>
                    {
                        btn2.Enabled = true;
                        Process.Start("cmd.exe", "/k ipconfig /flushdns");
                    });
                });
            }
        }
    }
}
