using ProgrammingCode.DAL.MST.MST_Level;
using ProgrammingCode.DAL.MST.MST_ProgrammingLanqauge;
using ProgrammingCode.DAL.MST.MST_Topic;
using ProgrammingCode.DAL.PRO.PRO_Program;
using ProgrammingCode.DAL.PRO.PRO_ProgramSolution;
using ProgrammingCode.DAL.SEC.SEC_User;

namespace ProgrammingCode.DAL
{
    public class DBConfig
    {
        public static MST_ProgrammingLangaugeDAL LangaugeMST = new MST_ProgrammingLangaugeDAL();
        public static PRO_ProgramTopic LevelMST = new PRO_ProgramTopic();
        public static MST_TopicDAL TopicMST = new MST_TopicDAL();
        public static PRO_ProgramDAL ProgramPRO=new PRO_ProgramDAL();
        public static SEC_UserDAL UserSEC = new SEC_UserDAL();
        public static PRO_ProgramSolutionDAL SolutionPRO= new PRO_ProgramSolutionDAL();
    
    }
}
