/**
* Copyright 2016 IBM Corp.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Worklight;

namespace StepUpWin10
{
    public class PinCodeChallengeHandler : Worklight.SecurityCheckChallengeHandler
    {
        public JObject challengeAnswer { get; set; }

        public override string SecurityCheck
        {
            get; set;
        }

        private bool authSuccess = false;
        private bool shouldsubmitchallenge = false;
        private bool shouldsubmitfailure = false;
        private string Realm;

        public static ManualResetEvent waitForPincode = new ManualResetEvent(false);

        public PinCodeChallengeHandler(String securityCheck)
        {
            Realm = securityCheck;
        }

        public override JObject GetChallengeAnswer()
        {
            return this.challengeAnswer;
        }

        public override void HandleChallenge(Object challenge)
        {

            waitForPincode.Reset();
            MainPage._this.showPinChallenge(challenge);
            shouldsubmitchallenge = true;
            waitForPincode.WaitOne();
        }

        public override bool ShouldCancel()
        {
            return shouldsubmitfailure;
        }

        public override bool ShouldSubmitChallengeAnswer()
        {
            return this.shouldsubmitchallenge;
        }


        public void SetShouldSubmitChallenge(bool shouldsubmitchallenge)
        {
            this.shouldsubmitchallenge = shouldsubmitchallenge;
        }

        public void SetSubmitFailure(bool shouldsubmitfailure)
        {
            this.shouldsubmitfailure = shouldsubmitfailure;
        }

        public override void HandleFailure(JObject error)
        {
            Debug.WriteLine("Error");
        }

        public override void HandleSuccess(JObject identity)
        {
            Debug.WriteLine("Success");
        }

        public override void SubmitChallengeAnswer(object answer)
        {
            challengeAnswer = (JObject)answer;
        }

        public async Task logout(String SecurityCheck)
        {
            WorklightResponse response = await WorklightClient.CreateInstance().AuthorizationManager.Logout(SecurityCheck);

        }

    }
}
