$source = "C:\Users\sprakash\Documents\Visual Studio 2017\Projects\ItunesWoxPlug\ItunesWoxPlugin\bin\Debug"
$destination = "C:\Users\sprakash\Documents\Visual Studio 2017\Projects\ItunesWoxPlug\ItunesWoxPlugin\bin\ItunesBuild.wox"

 If(Test-path $destination) {Remove-item $destination}
Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($Source, $destination)