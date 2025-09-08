using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG
    {
        // Ваши данные для сохранения
        public int coins = 5; // Пример
        public int score = 0;
        public bool MusicActive = true;
        public List<int> OpenLevels = new List<int> { 1,21, 41, 61 };
    }
}
