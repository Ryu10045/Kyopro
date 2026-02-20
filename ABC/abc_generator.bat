@echo off
setlocal enabledelayedexpansion

REM --- ユーザー入力 ---
set /p CONTEST_NAME="Contest Name (e.g., ABC350): "

REM --- ディレクトリ作成 ---
if not exist %CONTEST_NAME% (
    mkdir %CONTEST_NAME%
)
cd %CONTEST_NAME%

REM --- ソリューションファイルの作成 ---
dotnet new sln -n %CONTEST_NAME%

REM --- AからFまでループしてプロジェクト作成 ---
for %%P in (A B C D E F) do (
    echo Creating Project %%P...
    
    REM コンソールアプリの作成
    dotnet new console -o %%P --use-program-main
    REM ソリューションへの追加
    dotnet sln add %%P/%%P.csproj

    REM --- Program.cs の書き換え ---
    REM 注意: バッチファイル内でカッコ()を出力するため ^ でエスケープしています
    (
        echo using System;
        echo using System.Linq;
        echo using System.Collections.Generic;
        echo.
        echo public class %%P
        echo {
        echo     public static void Main^(^)
        echo     {
        echo     }
        echo }
    ) > %%P\Program.cs
)

echo.
echo ========================================================
echo  Created %CONTEST_NAME% projects (A-F) successfully!
echo ========================================================
pause