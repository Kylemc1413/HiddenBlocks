using System;
using System.Linq;
using UnityEngine;

namespace HiddenBlocks
{
	// Token: 0x02000003 RID: 3
	public class HiddenBlock : MonoBehaviour
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020A6 File Offset: 0x000002A6
		public void Awake()
		{
			this._note = base.GetComponent<NoteController>();
			this._mainCamera = Camera.main;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002258 File Offset: 0x00000458
		public void Update()
		{
			bool enableHiddenBlocks = Config.EnableHiddenBlocks;
			if (enableHiddenBlocks)
			{
                bool flag = _note?.transform != null && _mainCamera?.transform != null;
				if (flag)
				{
		     //			  bool flag2 = (!Plugin.NegativeNoteJumpSpeed && 
             //           this._note?.transform?.position.z <= this._mainCamera?.transform?.position.z + Config.BlockHideDistance)      
             //           || (Plugin.NegativeNoteJumpSpeed && this._note?.transform?.position.z >= this._mainCamera?.transform?.position.z - Config.BlockHideDistance);
                    bool hide = Vector3.Distance(_note.transform.position, _mainCamera.transform.position) <= Config.BlockHideDistance;

                    if (hide)
					{
						bool flag3 = !this._resetRenderers;
						if (flag3)
						{
							this._note?.GetComponentsInChildren<Renderer>()?.ToList<Renderer>()?.ForEach(delegate(Renderer r)
							{
								r.enabled = false;
							});
							this._resetRenderers = true;
						}
					}
					else
					{
						bool resetRenderers = this._resetRenderers;
						if (resetRenderers)
						{
							Renderer[] componentsInChildren = this._note?.GetComponentsInChildren<Renderer>();
                            var renderer = componentsInChildren.FirstOrDefault<Renderer>();
                            if(renderer)
                                renderer.enabled = true;
							this._resetRenderers = false;
						}
					}
				}
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		// Token: 0x04000004 RID: 4
		private NoteController _note = null;

		// Token: 0x04000005 RID: 5
		private Camera _mainCamera = null;

		// Token: 0x04000006 RID: 6
		private bool _resetRenderers = false;
	}
}
