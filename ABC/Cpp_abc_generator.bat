@echo off
setlocal enabledelayedexpansion

REM --- ユーザー入力 ---
set /p CONTEST_NAME="Contest Name (e.g., ABC350): "

xcopy /e /i ABC_template_cpp %CONTEST_NAME%


echo.
echo ========================================================
echo  Created %CONTEST_NAME% projects (A-F) successfully!
echo ========================================================
pause