#region CopyrightHeader
//
//  Copyright by Contributors
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//         http://www.apache.org/licenses/LICENSE-2.0.txt
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using gov.va.medora.mdo;

namespace gov.va.medora.mdws.dto
{
    public class VitalSignSetTO : AbstractTO
    {
        public string timestamp;
        public TaggedText facility;
        public VitalSignTO[] vitalSigns;
        public string units;
        public string qualifiers;

        public VitalSignSetTO() { }

        public VitalSignSetTO(VitalSignSet mdo)
        {
            this.timestamp = mdo.Timestamp;
            if (mdo.Facility != null)
            {
                this.facility = new TaggedText(mdo.Facility.Id, mdo.Facility.Name);
            }
            if (mdo.Count != 0)
            {
                VitalSign[] mdoSigns = mdo.VitalSigns;
                this.vitalSigns = new VitalSignTO[mdoSigns.Length];
                for (int i = 0; i < mdoSigns.Length; i++)
                {
                    this.vitalSigns[i] = new VitalSignTO(mdoSigns[i]);
                }
            }
            this.units = mdo.Units;
            this.qualifiers = mdo.Qualifiers;
        }
    }
}
