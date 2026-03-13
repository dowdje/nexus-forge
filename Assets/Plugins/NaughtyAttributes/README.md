# NaughtyAttributes Integration

This directory is a placeholder for [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes).

## Installation

### Option A: Unity Package Manager (Recommended)
1. Open Window > Package Manager
2. Click "+" > "Add package from git URL..."
3. Enter: `https://github.com/dbrizov/NaughtyAttributes.git#upm`

### Option B: Asset Store
1. Download from the [Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/naughtyattributes-129996)
2. Import the package into Unity

## Usage

NaughtyAttributes provides inspector enhancements like `[ShowIf]`, `[Button]`, `[Dropdown]`, `[MinMaxSlider]`, etc.

```csharp
using NaughtyAttributes;

[ShowIf("_isEnabled")]
[SerializeField] private float _speed;

[Button]
private void ResetToDefaults() { /* ... */ }
```
