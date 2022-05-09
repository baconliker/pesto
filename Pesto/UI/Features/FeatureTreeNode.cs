using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI.Features
{
	class FeatureTreeNode : System.Windows.Forms.TreeNode
	{
		public enum FeatureTreeNodeType
		{
			NoFlyZonesGroup,
			AirfieldGroup,
			DecksGroup,
			PointsGroup,
			GatesGroup,
			Feature
		}

		public FeatureTreeNode(string text, FeatureTreeNodeType type, Models.Features.Feature feature) 
			: base(text)
		{
			if (type == FeatureTreeNodeType.Feature && feature == null)
			{
				throw new ArgumentException();
			}

			this.Type = type;
			this.Feature = feature;
		}

		public FeatureTreeNode(string text, FeatureTreeNodeType type)
			: this(text, type, null)
		{
		}

		public static string BuildText(FeatureTreeNodeType type, Models.Features.Feature feature)
		{
			string text = string.Empty;

			switch (type)
			{
				case FeatureTreeNodeType.NoFlyZonesGroup:
					text = "No Fly Zones";
					break;
				case FeatureTreeNodeType.AirfieldGroup:
					text = "Airfield";
					break;
				case FeatureTreeNodeType.DecksGroup:
					text = "Decks";
					break;
				case FeatureTreeNodeType.PointsGroup:
					text = "Points";
					break;
				case FeatureTreeNodeType.GatesGroup:
					text = "Gates";
					break;
				case FeatureTreeNodeType.Feature:
					text = feature.Name;
					break;
			}

			return text;
		}

		public static string BuildText(FeatureTreeNodeType type)
		{
			return BuildText(type, null);
		}

		public FeatureTreeNodeType Type { get; set; }
		public Models.Features.Feature Feature { get; set; }
	}
}
