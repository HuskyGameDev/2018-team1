using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress : MonoBehaviour {

	public static Progress current;
	public List<world> worlds;


	[System.Serializable]
	public class world {
		[System.Serializable]
		public class levelDat {
			private bool completed;
			private int levelType; // 0 for platform or 1 for flatland, until better standard implemented

			public levelDat() {
				completed = false;
				levelType = 0;
			}

			public levelDat(bool completed, int levelType) {
				this.completed = completed;
				this.levelType = levelType;
			}

			public bool getCompleted() {
				return completed;
			}

			public void setCompleted(bool completed) {
				this.completed = completed;
			}

			public int getLevelType() {
				return levelType;
			}

			public void setLevelType(int levelType) {
				this.levelType = levelType;
			}
		}

		private List<levelDat> levelList;
		public world() {
			levelList = new List<levelDat>();
		}
		
		//might go unused, if so, refactor & remove later
		public world(List<levelDat> levelList) {
			this.levelList = levelList;
		}

		public world(List<bool> comp, List<int> type) {
			int length = comp.Count;
			if ( type.Count < length ) {
				length = type.Count;
			}

			levelList = new List<levelDat>();

			for ( int i = 0; i < length; i++ ) {
				levelList.Add(new levelDat(comp[i], type[i]));
			}
		}

		public void levelComplete(int level) {
			levelList[level].setCompleted(true);
		}

	}

	public Progress() {
		//TODO: add level list code here. Temp 1 platform & 1 flatlands added
		List<bool> levComp = new List<bool>();
		levComp.Add(false);
		levComp.Add(false);
		List<int> levType = new List<int>();
		levType.Add(0);
		levType.Add(1);

		worlds = new List<world>();
		worlds.Add(new world(levComp, levType));


		//TODO: add PlayerInfo to Progress

	}

}
