# Prompt the user for the main directory path
$mainDirectoryPath = Read-Host "Enter the path of the main directory containing the subfolders"

# Check if the main directory exists
if (-Not (Test-Path -LiteralPath $mainDirectoryPath -PathType Container))
{
    Write-Host "The specified main directory does not exist. Please check the path and try again." -ForegroundColor Red
    exit
}

# Ask the user if they want to rename all folders without asking for confirmation
$renameAll = Read-Host "Do you want to rename all folders without asking for confirmation? (Y to rename all, N to ask for each folder)"

# Retrieve all subfolders
$subfolders = Get-ChildItem -LiteralPath $mainDirectoryPath -Directory

# Process each subfolder
foreach ($subfolder in $subfolders)
{
    $originalName = $subfolder.Name
    $newName = $originalName

    # Remove all text within square brackets [] or parentheses () on the right side of the folder name
    do
    {
        $previousName = $newName
        $newName = $newName -replace '\s*[\[\(][^\[\(\]\)]*[\]\)]$', ''
    } while ($newName -ne $previousName)

    # If the name has changed, print the new name and ask for confirmation if needed
    if ($originalName -ne $newName)
    {
        Write-Host "`nOriginal Name: '$originalName'" -ForegroundColor Yellow
        Write-Host "New Name: '$newName'" -ForegroundColor Green

        if ($renameAll -match "^[Yy]$")
        {
            $confirmation = "Y"
        }
        else
        {
            $confirmation = Read-Host "Do you want to rename this folder? (Y to rename, N to skip)"
        }

        if ($confirmation -match "^[Yy]$")
        {
            $newFolderPath = Join-Path -Path $mainDirectoryPath -ChildPath $newName
            Rename-Item -LiteralPath $subfolder.FullName -NewName $newFolderPath
            Write-Host "Renamed '$originalName' to '$newName'" -ForegroundColor Green
        }
        else
        {
            Write-Host "Skipped renaming '$originalName'" -ForegroundColor Red
        }
    }
    else
    {
        Write-Host "`nNo changes needed for '$originalName'" -ForegroundColor Cyan
    }
}

Write-Host "`nAll folders processed." -ForegroundColor Green