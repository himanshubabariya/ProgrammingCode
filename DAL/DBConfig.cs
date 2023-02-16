using ProgrammingCode.DAL.MST.MST_Level;

using ProgrammingCode.DAL.MST.MST_ProgrammingLanqauge;
using ProgrammingCode.DAL.MST.MST_Topic;

namespace ProgrammingCode.DAL
{
    public class DBConfig
    {
        public static MST_ProgrammingLangaugeDAL LangaugeMST = new MST_ProgrammingLangaugeDAL();
        public static PRO_ProgramTopic LevelMST = new PRO_ProgramTopic();
        public static MST_TopicDAL TopicMST = new MST_TopicDAL();
    }
}
