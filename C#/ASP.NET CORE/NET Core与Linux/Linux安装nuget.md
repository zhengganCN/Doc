# 安装nuget

1. 安装 Mono 4.4.2 或更高版本。
2. 在shell 提示符处，执行下列命令：

``` shell
# Download the latest stable `nuget.exe` to `/usr/local/bin`
sudo curl -o /usr/local/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
```

3. 通过将以下脚本添加到 OS 的相应文件来创建别名（通常为 ~/.bash_aliases 或 ~/.bash_profile）：

```shell
# Create as alias for nuget
alias nuget="mono /usr/local/bin/nuget.exe"
```

4. 重载 shell。 通过输入 nuget（而不使用任何参数）来测试安装。 应该会看到 NuGet CLI 帮助。

    重载 shell: su - root
