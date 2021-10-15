﻿/*
	This file is part of Airplane+ /L
	© 2021 LisiasT : http://lisias.net <support@lisias.net>

	The Source Code for Airplane+ /L is double licensed, as follows:

	* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
	* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Airplane+ /Ll is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Airplane+ /L. If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Airplane+ /L. If not, see <https://www.gnu.org/licenses/>.

*/
using UnityEngine;
using KSPe.Annotations;

namespace AirplanePlus
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	public class Startup : MonoBehaviour
	{
		[UsedImplicitly]
		private void Start()
		{
			Log.force("Version {0}", Version.Text);

			try
			{
				KSPe.Util.Installation.Check<Startup>();
				this.checkDependencies("Firespitter");
			}
			catch (KSPe.Util.InstallmentException e)
			{
				Log.error(e.ToShortMessage());
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
			}
			catch (System.DllNotFoundException e)
			{
				Log.error(this, e);
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e.ToString());
			}
		}

		private void checkDependencies(string assemblyName)
		{
			if (KSPe.Util.SystemTools.Assembly.Finder.ExistsByName(assemblyName))
			{
				System.Reflection.Assembly assembly = KSPe.Util.SystemTools.Assembly.Finder.FindByName(assemblyName);
				Log.detail("Found {0}", assembly.FullName);
				return;
			}
			GUI.UnmetRequirementsShowStopperAlertBox.Show(assemblyName);
		}
	}
}
