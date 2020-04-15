﻿/*
Copyright 2015 Google Inc
Licensed under the Apache License, Version 2.0(the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Google.Apis.Calendar.v3;
using Google.Apis.Tasks.v1;

namespace Calendar.ASP.NET.MVC5
{
    internal static class MyRequestedScopes
    {
        public static string[] Scopes
        {
            get
            {
                return new[] {
                    "openid",
                    "email",
                    TasksService.Scope.Tasks,
                    CalendarService.Scope.Calendar,
                };
            }
        }
    }
}