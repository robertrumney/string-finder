# StringFinder

A Unity Editor tool to find and replace serialized strings in the scene.

## Overview

StringFinder is a Unity Editor extension designed to help developers easily find and replace serialized strings within their scenes. This tool can be particularly useful for large projects where manually searching for strings across multiple GameObjects and components can be time-consuming and error-prone.

## Features

- **Search for Serialized Strings:** Quickly find all serialized strings in the scene that contain a specified substring.
- **Replace Serialized Strings:** Replace all instances of the specified substring with a new string.
- **Select GameObjects:** Click on search results to highlight and select the corresponding GameObject in the Unity hierarchy.

## Installation

1. Clone or download this repository.
2. Copy the `SerializedStringFinder.cs` script into the `Editor` folder of your Unity project.

## Usage

1. Open Unity and navigate to `Tools > Serialized String Finder` to open the tool.
2. Enter the substring you want to search for in the "Search String" input field.
3. Enter the replacement string in the "Replace String" input field.
4. Click the "Find" button to search for all serialized strings in the scene that contain the specified substring.
5. Click the "Replace All" button to replace all found instances with the replacement string.
6. Click on any result to select the corresponding GameObject in the hierarchy.

## Why This Is Useful

- **Efficiency:** Automate the tedious process of searching and replacing strings across multiple GameObjects and components.
- **Accuracy:** Reduce the risk of missing instances or making errors when manually editing strings.
- **Convenience:** Easily navigate to and manage serialized string fields directly from the search results.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests to improve this tool.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
****
