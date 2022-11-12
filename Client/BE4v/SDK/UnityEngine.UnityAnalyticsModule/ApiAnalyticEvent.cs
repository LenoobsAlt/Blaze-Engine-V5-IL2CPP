﻿namespace UnityEngine
{
    public enum ApiAnalyticEvent
    {
        Search_ManualSearch,
        Search_SelectWorldTag,
        Search_AddSavedSearch,
        Search_RemoveSavedSearch,
        Social_UpdateStatus,
        Menu_addWorldToPlaylist,
        Menu_userDetailsClickPlaylist,
        Social_AcceptFriendRequest,
        Social_SendFriendRequest,
        Signup_AccountInfoUpdated,
        Signup_AccountCreated,
        Moderation_AvatarVisibilityResetByUser,
        Moderation_ResetShowUserAvatarToDefault,
        Moderation_AvatarShownByUser,
        Moderation_AvatarHiddenByUser,
        Moderation_HideUserAvatar,
        Moderation_ShowUserAvatar,
        Moderation_MutedByUser,
        Moderation_MuteUser,
        Moderation_BlockedByUser,
        Moderation_BlockUser,
        Moderation_ReceiveBan,
        Moderation_SendBan,
        Moderation_ReceiveKick,
        Moderation_SendKick,
        Moderation_ReceiveWarning,
        Moderation_SendWarning,
        Signup_AgreeToTOS,
        Signup_ViewTOSScreen,
        SafetySettingsChanged,
        Login_AccountVerificationCheckFailed,
        Error
    }
}