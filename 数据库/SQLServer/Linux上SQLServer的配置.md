# 配置

``` shell
[filelocation]
defaultbackupdir = /var/opt/mssql/data/  # 默认备份目录位置
defaultdatadir = /var/opt/mssql/data/    # 默认数据或日志目录位置
defaultdumpdir = /var/opt/mssql/data/    # 默认转储目录位置
defaultlogdir = /var/opt/mssql/data/     # 默认数据或日志目录位置

[hadr]
hadrenabled = 0 # 高可用性，设置为 1 来启用可用性组。

[language]
lcid = 2052  # SQL Server 区域设置，2052代表 中文（中国）

# [memory]
# memorylimitmb = 4096 # 设置可控制 SQL Server 可用的物理内存量（以 MB 为单位）。 默认值为物理内存的 80%。
```
