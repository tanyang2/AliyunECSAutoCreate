# AliyunECSAutoCreate
调用阿里云api自动创建服务器

运行环境 .net 4.5及以上

配置文件说明：

AccessKeyId：阿里云api密钥id

AccessSecret：阿里云api密钥

RegionId：阿里云区域，默认 ap-southeast-1 为新加坡

InstanceName:新建的服务器名称，默认 “shadowsocks-server”

LaunchTemplateName：新建服务器调用的模板，默认“shadowsocks”

DomainRecordId：自动更新域名解析的记录id

DomainRecordRR：自动更新域名解析的RR值，如 aa.abc.com，RR值为 “aa”

获取 RegionId 的地址

https://api.aliyun.com/?spm=a2c1g.8271268.10000.1.f906df25MTdOOF#/?product=Ecs&version=2014-05-26&api=DescribeRegions&tab=DOC&lang=CSHARP

{
				"RegionId": "cn-qingdao",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "华北 1"
			},
			
			{
				"RegionId": "cn-beijing",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "华北 2"
			},
			
			{
				"RegionId": "cn-zhangjiakou",
				"RegionEndpoint": "ecs.cn-zhangjiakou.aliyuncs.com",
				"LocalName": "华北 3"
			},
			
			{
				"RegionId": "cn-huhehaote",
				"RegionEndpoint": "ecs.cn-huhehaote.aliyuncs.com",
				"LocalName": "华北 5"
			},
			
			{
				"RegionId": "cn-hangzhou",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "华东 1"
			},
			
			{
				"RegionId": "cn-shanghai",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "华东 2"
			},
			
			{
				"RegionId": "cn-shenzhen",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "华南 1"
			},
			
			{
				"RegionId": "cn-heyuan",
				"RegionEndpoint": "ecs.cn-heyuan.aliyuncs.com",
				"LocalName": "华南2（河源）"
			},
			
			{
				"RegionId": "cn-chengdu",
				"RegionEndpoint": "ecs.cn-chengdu.aliyuncs.com",
				"LocalName": "西南1（成都）"
			},
			
			{
				"RegionId": "cn-hongkong",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "香港"
			},
			
			{
				"RegionId": "ap-northeast-1",
				"RegionEndpoint": "ecs.ap-northeast-1.aliyuncs.com",
				"LocalName": "亚太东北 1 (东京)"
			},
			
			{
				"RegionId": "ap-southeast-1",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "亚太东南 1 (新加坡)"
			},
			
			{
				"RegionId": "ap-southeast-2",
				"RegionEndpoint": "ecs.ap-southeast-2.aliyuncs.com",
				"LocalName": "亚太东南 2 (悉尼)"
			},
			
			{
				"RegionId": "ap-southeast-3",
				"RegionEndpoint": "ecs.ap-southeast-3.aliyuncs.com",
				"LocalName": "亚太东南 3 (吉隆坡)"
			},
			
			{
				"RegionId": "ap-southeast-5",
				"RegionEndpoint": "ecs.ap-southeast-5.aliyuncs.com",
				"LocalName": "亚太东南 5 (雅加达)"
			},
			
			{
				"RegionId": "ap-south-1",
				"RegionEndpoint": "ecs.ap-south-1.aliyuncs.com",
				"LocalName": "亚太南部 1 (孟买)"
			},
			
			{
				"RegionId": "us-east-1",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "美国东部 1 (弗吉尼亚)"
			},
			
			{
				"RegionId": "us-west-1",
				"RegionEndpoint": "ecs.aliyuncs.com",
				"LocalName": "美国西部 1 (硅谷)"
			},
			
			{
				"RegionId": "eu-west-1",
				"RegionEndpoint": "ecs.eu-west-1.aliyuncs.com",
				"LocalName": "英国 (伦敦)"
			},
			
			{
				"RegionId": "me-east-1",
				"RegionEndpoint": "ecs.me-east-1.aliyuncs.com",
				"LocalName": "中东东部 1 (迪拜)"
			},
			
			{
				"RegionId": "eu-central-1",
				"RegionEndpoint": "ecs.eu-central-1.aliyuncs.com",
				"LocalName": "欧洲中部 1 (法兰克福)"
			}
      
获取 DomainRecordId 地址：

https://api.aliyun.com/?spm=a2c1g.8271268.10000.1.f906df25MTdOOF#/?product=Alidns&version=2015-01-09&api=DescribeDomainRecords&tab=DEMO&lang=CSHARP

输入 DomainName ，点发起调用

