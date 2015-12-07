﻿// Copyright © 2015 - Present RealDimensions Software, LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//
// You may obtain a copy of the License at
//
// 	http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace chocolatey.package.validator.infrastructure.app.rules
{
    using System.Linq;
    using infrastructure.rules;
    using NuGet;

    public class DependencyWithNoVersionGuideline : BasePackageRule
    {
        public override string ValidationFailureMessage { get { return "Package contains dependencies with no specified version, which is not recommended..  Please see [wiki article](https://github.com/chocolatey/package-validator/wiki/DependencyWithNoVersion) for further information and guidance."; } }

        protected override PackageValidationOutput is_valid(IPackage package)
        {
            return !package.DependencySets.Any(dependencySet => dependencySet.Dependencies.Any(dependency => dependency.VersionSpec.MaxVersion == null || dependency.VersionSpec.MinVersion == null));
        }
    }
}