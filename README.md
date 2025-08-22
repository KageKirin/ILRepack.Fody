# <img src="Icon.png" alt="ILRepack.Fody icon" height="50px" /> ILRepack.Fody

Fody add-in using ILRepack to merge dependency assemblies into the target assembly.

Note: the NuGet package is called **KageKirin.ILRepack.Fody** to allow alternative implementations.

### This is an add-in for [Fody](https://github.com/Fody/Home/)

**It is expected that all developers using Fody [become a Patron on OpenCollective](https://opencollective.com/fody/contribute/patron-3059). [See Licensing/Patron FAQ](https://github.com/Fody/Home/blob/master/pages/licensing-patron-faq.md) for more information.**


## ⚡ Usage

### Add Fody and ILRepack.Fody

```xml
<Project>
  <PackageReference Include="Fody" Version="6.9.2" />
  <PackageReference Include="KageKirin.ILRepack.Fody" Version="0.0.0" />
</Project>
```

### 🔧 Add to FodyWeavers.xml

Add `<ILRepack />` to FodyWeavers.xml

```xml
<Weavers>
  <ILRepack />
</Weavers>
```

### 🔨 Configure `<ILRepack />`

TBD

## 🤝 Collaborate with My Project

Please refer to [COLLABORATION.md](COLLABORATION.md).
