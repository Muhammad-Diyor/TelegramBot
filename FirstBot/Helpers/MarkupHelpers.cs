﻿using Telegram.Bot.Types.ReplyMarkups;

namespace FirstBot.Helpers;

public static class MarkupHelpers
{
    public static InlineKeyboardMarkup GetInlineKeyboardMatrix(Dictionary<string, string> keys, int columns = 2)
    {
        int row = 0;
        
        var buttonMatrix = new List<List<InlineKeyboardButton>>();

        while (keys.Skip(row).Take(columns)?.Count() > 0)
        {
            var buttons = keys.Skip(row * columns).Take(columns).Select(k => InlineKeyboardButton.WithCallbackData(k.Value, k.Key)).ToList();

            buttonMatrix.Add(buttons);

            row++;
        }

        return new InlineKeyboardMarkup(buttonMatrix.ToArray());
    }

    public static ReplyKeyboardMarkup GetReplyKeyboardMarkup(string[] keys, int columns = 2)
    {
        var buttons = keys.Select(k => new KeyboardButton(k));
        var keyboardMarkup = new ReplyKeyboardMarkup(buttons);
        keyboardMarkup.ResizeKeyboard = true;
        return keyboardMarkup;
    }
}