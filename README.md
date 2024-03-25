# Folder Maker

**Folder Maker** is a lightweight **C# .NET console application** designed to streamline the process of creating multiple folders within a specified directory. Whether you're organizing files, managing projects, or simply need to create a series of folders, this tool simplifies the task.

## Features

- **Efficient Folder Creation**: Specify the target directory, folder name, start number, and end number. The application swiftly generates a sequence of folders (e.g., "Day 1," "Day 2," ... "Day 5") in the chosen path.

## How It Works

1. **User Input**: Provide the following details:
   - **Path**: The directory where the folders will be created (e.g., `C:\`).
   - **Folder Name**: The base name for the folders (e.g., "Day").
   - **Start Number**: The initial numeric value (e.g., 1).
   - **End Number**: The final numeric value (e.g., 5).

2. **Automated Folder Creation**: The application generates folders with names like "Day 1," "Day 2," and so on, up to the specified end number.

## Usage

Download and Run the single executable file from the Setup folder and provide the inputs.

## Example

https://youtu.be/q1j_g9ycmCw

Suppose you want to organize daily reports. Using **Folder Maker**, you can create folders like:
- `C:\Day 1`
- `C:\Day 2`
- ...
- `C:\Day 5`

## Development
1. Program.cs file contains the code.
2. dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "path" 
    above dotnet command is used to publish a single executable file.
3. [A certificate to the executable file is added](https://youtu.be/m77p30bvY5E), to prevent Windows Defender from flagging it as a potential virus.<br>
    Downloaded and Installed Windows SDK and generated certificates with below commands.<br>
    -$cert = New-SelfSignedCertificate -Subject "Folder-Maker" -CertStoreLocation "cert:\CurrentUser\My" -HashAlgorithm sha256 -type CodeSigning <br>
    -signtool.exe sign /f Folder-Maker.pfx /fd SHA256 /p qwertyui Folder-Maker.exe<br>

## Contributions
Contributions are welcome! Feel free to enhance the application, add error handling, or suggest improvements.