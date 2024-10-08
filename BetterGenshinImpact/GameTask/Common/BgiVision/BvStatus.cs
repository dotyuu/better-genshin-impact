﻿using BetterGenshinImpact.GameTask.Common.Element.Assets;
using BetterGenshinImpact.GameTask.Model.Area;
using BetterGenshinImpact.GameTask.QuickTeleport.Assets;
using System;

namespace BetterGenshinImpact.GameTask.Common.BgiVision;

/// <summary>
/// 模仿OpenCv的静态类
/// 用于原神的各类识别与控制操作
///
/// 此处主要是对游戏内的一些状态进行识别
/// </summary>
public static partial class Bv
{
    public static string WhichGameUi()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 是否在主界面
    /// </summary>
    /// <param name="captureRa"></param>
    /// <returns></returns>
    public static bool IsInMainUi(ImageRegion captureRa)
    {
        return captureRa.Find(ElementAssets.Instance.PaimonMenuRo).IsExist();
    }

    /// <summary>
    /// 是否在大地图界面
    /// </summary>
    /// <param name="captureRa"></param>
    /// <returns></returns>
    public static bool IsInBigMapUi(ImageRegion captureRa)
    {
        return captureRa.Find(QuickTeleportAssets.Instance.MapScaleButtonRo).IsExist();
    }

    /// <summary>
    /// 大地图界面是否在地底
    /// 鼠标悬浮在地下图标或者处于切换动画的时候可能会误识别
    /// </summary>
    /// <param name="captureRa"></param>
    /// <returns></returns>
    public static bool BigMapIsUnderground(ImageRegion captureRa)
    {
        return captureRa.Find(QuickTeleportAssets.Instance.MapUndergroundSwitchButtonRo).IsExist();
    }

    public static MotionStatus GetMotionStatus(ImageRegion captureRa)
    {
        var spaceExist = captureRa.Find(ElementAssets.Instance.SpaceKey).IsExist();
        var xExist = captureRa.Find(ElementAssets.Instance.XKey).IsExist();
        if (spaceExist)
        {
            return xExist ? MotionStatus.Climb : MotionStatus.Fly;
        }
        else
        {
            return MotionStatus.Normal;
        }
    }
}

public enum MotionStatus
{
    Normal, // 正常
    Fly, // 飞行
    Climb, // 攀爬
}
