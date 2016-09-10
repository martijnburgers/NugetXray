﻿using System;
using System.Collections.Generic;
using System.Linq;
using NugetXray.Diff;
using NuGet.Packaging;
using NuGet.Versioning;

namespace NugetXray.Duplicate
{
    public class PackageDuplicateDetector
    {
        public PackageDuplicate[] FindDuplicates(Dictionary<string, PackageReference[]> packages)
        {
            var groupedById = packages.SelectMany(x => x.Value.Select(y => new {PackageReference = y, Config = x.Key}))
                                      .GroupBy(x => x.PackageReference.PackageIdentity.Id);

            var duplicates = groupedById.Where(x => x.Select(y => y.PackageReference.PackageIdentity.Version).Distinct().Count() > 1);

            return duplicates.Select(x => new PackageDuplicate(
                x.First().PackageReference, 
                x.Select(y => Tuple.Create(y.PackageReference.PackageIdentity.Version as SemanticVersion, y.Config)).ToArray())).ToArray();
        }
    }
}