using NXOpen;
using NXOpen.CAE;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpenUI;
using NXOpen.BlockStyler;
using System.Drawing;
using NXOpen.Features.ShipDesign;
using static NXOpen.CAE.Post;
using NXOpen.Utilities;

namespace Arong_Nx
{
	static class Arong_Nx_App
	{
		/// <summary>
		/// 返回dll的路径
		/// </summary>
		/// <returns></returns>
		static public string GetPath(string dlx)
		{
			return AppDomain.CurrentDomain.BaseDirectory + dlx;
		}
	}


	/// <summary>
	/// 预览相关类
	/// </summary>
	internal class Arong_Nx_Preview
	{
		UFCurve.Line line_coords;
		Tag line = Tag.Null;
		Tag arc = Tag.Null;
		UFCurve.Arc arc_coords;
		Tag matrix_id;

		/// <summary>
		/// 方形预览的tag
		/// </summary>
		List<Tag> ylboxtag = new List<Tag>();

		/// <summary>
		/// 圆形预览的tag
		/// </summary>
		List<Tag> ylcylindertag = new List<Tag>();

		/// <summary>
		/// 生成一个方块预览
		/// </summary>
		/// <param name="boxcatalot">方块的长宽高尺寸</param>
		/// <param name="Point">预览的坐标位置，默认为方块的中心</param>
		public void ylbox(int[] boxcatalot, Point3d Point)
		{
			ylboxtag.Clear();

			int L = boxcatalot[0];
			int W = boxcatalot[1];
			int H = boxcatalot[2];

			double zbL = Point.X;
			double zbW = Point.Y;
			double zbH = Point.Z;

			//底部四边形
			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			//顶部四边形
			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			//垂直线
			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);
		}

		/// <summary>
		/// 生成一个方块预览
		/// </summary>
		/// <param name="boxcatalot">方块的长宽高尺寸</param>
		/// <param name="Point">预览的坐标位置，默认为方块的中心</param>
		public void ylbox(int[] boxcatalot, double[] Point)
		{
			ylboxtag.Clear();

			int L = boxcatalot[0];
			int W = boxcatalot[1];
			int H = boxcatalot[2];

			double zbL = Point[0];
			double zbW = Point[1];
			double zbH = Point[2];

			//底部四边形
			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH - (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			//顶部四边形
			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH + (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			//垂直线
			line_coords.start_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW + (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL - (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW - (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);

			line_coords.start_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (L / 2), zbW + (W / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylboxtag.Add(line);
		}



		/// <summary>
		/// 生成一个圆柱预览
		/// </summary>
		/// <param name="cylindercatalot">圆柱的长高尺寸</param>
		/// <param name="Point">预览的坐标位置，默认为圆柱的中心</param>
		public void ylcylinder(int[] cylindercatalot, Point3d Point)
		{
			ylcylindertag.Clear();

			int D = cylindercatalot[0];
			int H = cylindercatalot[1];

			double zbL = Point.X;
			double zbW = Point.Y;
			double zbH = Point.Z;

			//上下圆弧
			arc_coords.start_angle = 0;
			arc_coords.end_angle = 2 * 3.14159265358979324;
			arc_coords.radius = D / 2;
			arc_coords.arc_center = new double[] { zbL, zbW, zbH + (H / 2) };

			double[] matrix_values1 = { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
			UFSession.GetUFSession().Csys.CreateMatrix(matrix_values1, out matrix_id);
			arc_coords.matrix_tag = matrix_id;
			UFSession.GetUFSession().Curve.CreateArc(ref arc_coords, out arc);
			ylcylindertag.Add(arc);

			arc_coords.start_angle = 0;
			arc_coords.end_angle = 2 * 3.14159265358979324;
			arc_coords.radius = D / 2;
			arc_coords.arc_center = new double[] { zbL, zbW, zbH - (H / 2) };

			double[] matrix_values2 = { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
			UFSession.GetUFSession().Csys.CreateMatrix(matrix_values2, out matrix_id);
			arc_coords.matrix_tag = matrix_id;
			UFSession.GetUFSession().Curve.CreateArc(ref arc_coords, out arc);
			ylcylindertag.Add(arc);

			//四边线
			line_coords.start_point = new double[] { zbL - (D / 2), zbW, zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL - (D / 2), zbW, zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylcylindertag.Add(line);

			line_coords.start_point = new double[] { zbL + (D / 2), zbW, zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL + (D / 2), zbW, zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylcylindertag.Add(line);

			line_coords.start_point = new double[] { zbL, zbW - (D / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL, zbW - (D / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylcylindertag.Add(line);

			line_coords.start_point = new double[] { zbL, zbW + (D / 2), zbH + (H / 2) };
			line_coords.end_point = new double[] { zbL, zbW + (D / 2), zbH - (H / 2) };
			UFSession.GetUFSession().Curve.CreateLine(ref line_coords, out line);
			ylcylindertag.Add(line);
		}

		/// <summary>
		/// 删除上一个预览
		/// </summary>
		public void deleteyl()
		{
			if (ylcylindertag.Count == 6)
			{
				for (int i = 0; i < ylcylindertag.Count; i++)
				{
					UFSession.GetUFSession().Obj.DeleteObject(ylcylindertag[i]);
				}
				ylcylindertag.Clear();
			}

			if (ylboxtag.Count == 12)
			{
				for (int i = 0; i < ylboxtag.Count; i++)
				{
					UFSession.GetUFSession().Obj.DeleteObject(ylboxtag[i]);
				}
				ylboxtag.Clear();
			}
		}
	}

	/// <summary>
	/// 特征相关类
	/// </summary>
	internal class Arong_Nx_Characteristic
	{
		/// <summary>
		/// 创建一个方块
		/// </summary>
		/// <param name="catalog">方块的长宽高</param>
		/// <param name="point">方块的位置</param>
		/// <returns></returns>
		public Tag Box(string[] catalog, double[] point)
		{
			NXOpen.UF.FeatureSigns sign = NXOpen.UF.FeatureSigns.Nullsign;//定义布尔
			Tag blk_obj_id2 = Tag.Null;
			UFSession.GetUFSession().Modl.CreateBlock1(sign, point, catalog, out blk_obj_id2);
			return blk_obj_id2;
		}
	}

	/// <summary>
	/// 装配相关类
	/// </summary>
	internal class Arong_Nx_Assemble
	{
		private static Session theSession = null;
		private static UI theUI = null;

		public Arong_Nx_Assemble()
		{
			theSession = Session.GetSession();
			theUI = UI.GetUI();
		}

		/// <summary>
		/// 新建一个新装配
		/// </summary>
		/// <param name="path">装配文件位置</param>
		/// <param name="name">装配名称，在组件中</param>
		public void NewAssemble(string path,string name)
		{
			Session theSession = Session.GetSession();
			Part workPart = theSession.Parts.Work;
			Part displayPart = theSession.Parts.Display;

			FileNew fileNew1;
			fileNew1 = theSession.Parts.FileNew();
			fileNew1.TemplateFileName = "model-plain-1-mm-template.prt";
			fileNew1.Application = FileNewApplication.Modeling;
			fileNew1.Units = NXOpen.Part.Units.Millimeters;
			fileNew1.RelationType = "";
			fileNew1.UsesMasterModel = "No";
			fileNew1.TemplateType = FileNewTemplateType.Item;
			fileNew1.NewFileName = path;
			fileNew1.MasterFileName = "";
			fileNew1.UseBlankTemplate = false;
			fileNew1.MakeDisplayedPart = false;

			NXOpen.Assemblies.CreateNewComponentBuilder createNewComponentBuilder1;
			createNewComponentBuilder1 = workPart.AssemblyManager.CreateNewComponentBuilder();
			createNewComponentBuilder1.NewComponentName = "22";
			createNewComponentBuilder1.ReferenceSet = NXOpen.Assemblies.CreateNewComponentBuilder.ComponentReferenceSetType.EntirePartOnly;
			createNewComponentBuilder1.ReferenceSetName = "PART";
			createNewComponentBuilder1.ComponentOrigin = NXOpen.Assemblies.CreateNewComponentBuilder.ComponentOriginType.Absolute;
			createNewComponentBuilder1.NewComponentName = name;

			createNewComponentBuilder1.NewFile = fileNew1;
			NXObject nXObject2;
			try
			{
				nXObject2 = createNewComponentBuilder1.Commit();
				createNewComponentBuilder1.Destroy();
			}
			catch (Exception ex)
			{
				theUI.NXMessageBox.Show("Arong_Nx_Assemble", NXMessageBox.DialogType.Error, ex.ToString());
			}
		}

		/// <summary>
		/// 添加一个装配
		/// </summary>
		public void AddAssemble()
		{
			Session theSession = Session.GetSession();
			Part workPart = theSession.Parts.Work;
			Part displayPart = theSession.Parts.Display;

			Point3d basePoint1 = new Point3d(0.0, 0.0, 0.0);
			Matrix3x3 orientation1;
			orientation1.Xx = 1.0;
			orientation1.Xy = 0.0;
			orientation1.Xz = 0.0;
			orientation1.Yx = 0.0;
			orientation1.Yy = 1.0;
			orientation1.Yz = 0.0;
			orientation1.Zx = 0.0;
			orientation1.Zy = 0.0;
			orientation1.Zz = 1.0;
			PartLoadStatus partLoadStatus2;
			NXOpen.Assemblies.Component component1;
			component1 = workPart.ComponentAssembly.AddComponent("C:\\Users\\QT-254\\Desktop\\PL.prt", "AAAA", "plaaa", basePoint1, orientation1, -1, out partLoadStatus2, true);

			partLoadStatus2.Dispose();
			NXObject[] objects1 = new NXObject[0];
			int nErrs2;
			nErrs2 = theSession.UpdateManager.AddToDeleteList(objects1);


		}


	}
}

