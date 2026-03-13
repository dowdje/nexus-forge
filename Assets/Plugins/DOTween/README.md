# DOTween Integration

This directory is a placeholder for [DOTween](http://dotween.demigiant.com/) (free version).

## Installation

1. Download DOTween Free from the [Unity Asset Store](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
2. Import the package into Unity (Assets > Import Package)
3. Run the DOTween setup panel (Tools > Demigiant > DOTween Utility Panel > Setup DOTween)
4. Files will be placed in this `Assets/Plugins/DOTween/` directory

## Usage

DOTween is used for UI animations, material property transitions, and camera effects.

```csharp
using DG.Tweening;

transform.DOMove(targetPosition, 0.5f).SetEase(Ease.OutQuad);
```
