@echo off
cd /d %~dp0

set SRC_DIR=..\GeneratedSources
set DST_STD_DIR=..\StandardServices
set DST_NON_STD_DIR=..\NonStandardServices

rem Forbid overwrite
If Not Exist %DST_NON_STD_DIR%\ALFrameManager.cs (
    copy %SRC_DIR%\ALFrameManager.cs %DST_NON_STD_DIR%\
)
If Not Exist %DST_NON_STD_DIR%\ALPythonBridge.cs (
    copy %SRC_DIR%\ALPythonBridge.cs %DST_NON_STD_DIR%\
)

for /f "tokens=1,2" %%i in (srcsetting.txt) do (
    If Not Exist %DST_STD_DIR%\%%i\%%j (
        copy %SRC_DIR%\%%j %DST_STD_DIR%\%%i\
    )
)



