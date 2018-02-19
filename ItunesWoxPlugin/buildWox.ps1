$source = "C:\Projects\WoxPlugin\PluginOutput\LooseFile\"
$destination = "C:\Projects\WoxPlugin\PluginOutput\ItunesBuild.wox"

 If(Test-path $destination) {Remove-item $destination}
Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($Source, $destination)