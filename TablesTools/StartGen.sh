#!/bin/zsh
WORKSPACE=..

GEN_CLIENT=${WORKSPACE}/TablesTools/Tools/Luban.ClientServer/Luban.ClientServer.dll
CONF_ROOT=${WORKSPACE}/TablesTools/Tables


dotnet ${GEN_CLIENT} -j cfg --\
 -d ${CONF_ROOT}/Defines/__root__.xml \
 --input_data_dir ${CONF_ROOT}/Datas \
 --output_code_dir Assets/Gen \
 --output_data_dir ../Assets/json \
 --gen_types code_cs_unity_json,data_json \
 -s all 