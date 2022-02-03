# RuichenCore



 采用仓储+服务+接口的形式封装框架；
 异步 async/await 开发；
 接入国产数据库ORM组件 —— SqlSugar，封装数据库操作；
 支持自由切换多种数据库，MySql/SqlServer/Sqlite/Oracle/Postgresql/达梦/人大金仓；
 实现项目启动，自动生成种子数据 ✨；
 五种日志记录，审计/异常/请求响应/服务操作/Sql记录等；
 支持项目事务处理（若要分布式，用cap即可）✨；
 设计4种 AOP 切面编程，功能涵盖：日志、缓存、审计、事务 ✨；
 支持 T4 代码模板，自动生成每层代码；
 或使用 DbFirst 一键创建自己项目的四层文件（支持多库）；
 封装Blog.Core.Webapi.Template项目模板，一键重建自己的项目 ✨；
 搭配多个前端案例供参考和借鉴：Blog.Vue、Blog.Admin、Nuxt.tbug、Blog.Mvp.Blazor ✨；
 统一集成 IdentityServer4 认证 ✨;
组件模块：

 提供 Redis 做缓存处理；
 使用 Swagger 做api文档；
 使用 MiniProfiler 做接口性能分析 ✨；
 使用 Automapper 处理对象映射；
 使用 AutoFac 做依赖注入容器，并提供批量服务注入 ✨；
 支持 CORS 跨域；
 封装 JWT 自定义策略授权；
 使用 Log4Net 日志框架，集成原生 ILogger 接口做日志记录；
 使用 SignalR 双工通讯 ✨；
 添加 IpRateLimiting 做 API 限流处理;
 使用 Quartz.net 做任务调度（目前单机多任务，集群调度暂不支持）;
 支持 数据库读写分离和多库操作 ✨;
 新增 Redis 消息队列 ✨;
 新增 RabbitMQ 消息队列 ✨;
 新增 EventBus 事件总线 ✨;
 新增 - 统一聚合支付;
 新增 - Nacos注册中心配置;
 新增 - ES 搜索配置;
 新增 - Apollo 配置;
 新增 Kafka 消息队列，并配合实现EventBus ✨;
 新增 微信公众号管理，并集成到Blog.Admin后台 ✨;
 计划 - 数据部门权限;
微服务模块：

 可配合 Docker 实现容器化；
 可配合 Jenkins 实现CI / CD；
 可配合 Consul 实现服务发现；
 可配合 Nacos 实现服务发现；
 可配合 Ocelot 实现网关处理；
 可配合 Nginx 实现负载均衡；
 可配合 Ids4 实现认证中心；
