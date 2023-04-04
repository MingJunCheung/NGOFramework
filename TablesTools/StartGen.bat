set WORKSPACE=..
 
set GEN_CLIENT=%WORKSPACE%\TablesTools\Tools\Luban.ClientServer\Luban.ClientServer.exe
set CONF_ROOT=%WORKSPACE%\TablesTools\Tables
 
%GEN_CLIENT% -j cfg --^
 -d %CONF_ROOT%\Defines\__root__.xml ^
 --input_data_dir %CONF_ROOT%\Datas ^
 --output_code_dir %WORKSPACE%/Assets/Scripts/TableScript ^
 --output_data_dir ..\Assets\StreamingAssets\TableJson ^
 --gen_types code_cs_unity_json,data_json ^
 -s all 
 
pause