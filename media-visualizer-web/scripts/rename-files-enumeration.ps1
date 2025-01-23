# Define default extension groups
$imageExtensions = @("jpg", "png", "jpeg", "gif", "bmp")
$documentExtensions = @("doc", "docx", "xls", "xlsx", "pdf", "txt")

# Prompt the user for the main directory path
$mainDirectoryPath = Read-Host "Enter the path of the main directory containing the subfolders"

# Check if the main directory exists
if (-Not (Test-Path -LiteralPath $mainDirectoryPath -PathType Container))
{
    Write-Host "The specified main directory does not exist. Please check the path and try again." -ForegroundColor Red
    exit
}

# Prompt the user for the extension set
Write-Output "Choose the type of extensions to filter:"
Write-Output "1. Image Default (jpg, png, jpeg, gif, bmp)"
Write-Output "2. Document Default (doc, docx, xls, xlsx, pdf, txt)"
Write-Output "3. Manual Input"
$choice = Read-Host "Enter your choice (1, 2, or 3)"

switch ($choice)
{
    "1" {
        $fileExtensions = $imageExtensions
    }
    "2" {
        $fileExtensions = $documentExtensions
    }
    "3" {
        $extensionsInput = Read-Host "Enter the file extensions to look for, separated by commas (e.g., jpg, png, txt)"
        $fileExtensions = $extensionsInput -split "," | ForEach-Object {
            if ( $_.StartsWith("."))
            {
                $_.Trim()
            }
            else
            {
                "." + $_.Trim()
            }
        }
    }
    Default {
        Write-Host "Invalid choice. Exiting script." -ForegroundColor Red
        exit
    }
}

$fileExtensions = $fileExtensions | ForEach-Object {
    if ( $_.StartsWith("."))
    {
        $_
    }
    else
    {
        "." + $_
    }
}

# Retrieve all subfolders, sorted alphabetically in ascending order
$subfolders = Get-ChildItem -LiteralPath $mainDirectoryPath -Directory | Sort-Object Name

# Prompt for the starting folder
$startFolderName = Read-Host "Enter the name of the folder from which to start (case-sensitive)"

# Find the starting index
$startIndex = [Array]::IndexOf($subfolders, ($subfolders | Where-Object { $_.Name -match [regex]::Escape($startFolderName) } | Select-Object -First 1))
if ($startIndex -eq -1)
{
    Write-Host "The specified start folder was not found in the main directory." -ForegroundColor Red
    exit
}

# Process each subfolder from the starting index to the end
for ($i = $startIndex; $i -lt $subfolders.Count; $i++) {
    $currentFolder = $subfolders[$i].FullName
    Write-Host "`nProcessing folder: $( $subfolders[$i].Name )" -ForegroundColor Green

    # Get files in the current folder with the specified extensions, sorted by name
    $files = Get-ChildItem -LiteralPath $currentFolder -File | Where-Object { $fileExtensions -contains $_.Extension } | Sort-Object Name

    $filesCount = $files.Count
    # Display files
    if ($filesCount -le 0)
    {
        Write-Host "No files with specified extensions found in $( $subfolders[$i].Name )." -ForegroundColor Red
        continue
    }

    # Check if the current padding is correct
    $correctPadding = $filesCount.ToString().Length
    $hasCorrectPadding = $false
    if ($files[0].Name -match '^\d+')
    {
        $currentPadding = $matches[0].Length
        if ($currentPadding -eq $correctPadding)
        {
            $hasCorrectPadding = $true
        }
    }

    # Determine the most common extension
    $extensionCounts = @{ }
    $hasOneExtension = $false
    foreach ($file in $files)
    {
        if ( $extensionCounts.ContainsKey($file.Extension))
        {
            $extensionCounts[$file.Extension]++
        }
        else
        {
            $extensionCounts[$file.Extension] = 1
        }
    }
    $mostCommonExtension = $extensionCounts.GetEnumerator() | Sort-Object Value -Descending | Select-Object -First 1 | ForEach-Object { $_.Key }
    $hasOneExtension = $extensionCounts.Count -eq 1

    if ($hasCorrectPadding -and $hasOneExtension)
    {
        continue
    }

    $files | ForEach-Object { Write-Output $_.Name }

    # Ask user if they want to rename files in this folder
    $renameChoice = Read-Host "Do you want to rename files in this folder? (Y to rename, N to skip)"
    if ($renameChoice -notmatch "^[Yy]$")
    {
        continue
    }

    # Rename each file
    $count = 1
    foreach ($file in $files)
    {
        $newName = "{0:D$correctPadding}" -f $count + $mostCommonExtension
        $newFilePath = Join-Path -Path $currentFolder -ChildPath $newName
        Rename-Item -LiteralPath $file.FullName -NewName $newFilePath
        Write-Host "$( $file.Name ) -> $( $newName )"
        $count++
    }
    Write-Host "Files have been renamed successfully in $( $subfolders[$i].Name )." -ForegroundColor Green
}

Write-Output "All folders processed."
