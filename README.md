IBM MobileFirst Platform Foundation
===
## StepUpWin10
A sample application demonstrating the use of multiple challenge handlers.

### Tutorials

### Usage

1. From a command-line window, navigate to the project's root folder and register the application: `mfpdev app register`
2. Use either Maven or MobileFirst Developer CLI to [build and deploy the available `ResourceAdapter`, `StepUpUserLogin` and `StepUpPinCode` adapters](https://mobilefirstplatform.ibmcloud.com/tutorials/en/foundation/8.0/adapters/creating-adapters/).
3. In the MobileFirst console, under **Applications** → **StepUpWin10** → **Security** → **Map scope elements to security checks**, add a mapping from `accessRestricted` to `StepUpUserLogin`.
4. Add a mapping from `transferPrivilege` to both `StepUpUserLogin` and `StepUpPinCode`.
5. In Visual Studio, run the application

SecurityCheck adapter: https://github.com/MobileFirst-Platform-Developer-Center/SecurityCheckAdapters/tree/release80

### Supported Levels
IBM MobileFirst Platform Foundation 8.0

### License
Copyright 2016 IBM Corp.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
