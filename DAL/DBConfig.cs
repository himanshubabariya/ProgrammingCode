using ProgrammingCode.DAL.MST.MST_Level;
using ProgrammingCode.DAL.MST.MST_ProgrammingLanqauge;
using ProgrammingCode.DAL.MST.MST_Topic;
using ProgrammingCode.DAL.PRO.PRO_Program;
using ProgrammingCode.DAL.PRO.PRO_ProgramSolution;
using ProgrammingCode.DAL.PRO.PRO_ProgramTestCase;
using ProgrammingCode.DAL.SEC.SEC_User;

namespace ProgrammingCode.DAL
{
    public class DBConfig
    {
        public static MST_ProgrammingLangaugeDAL dbLangauge = new MST_ProgrammingLangaugeDAL();
        public static MST_LevelDAL dbLevel = new MST_LevelDAL();
        public static MST_TopicDAL dbTopic = new MST_TopicDAL();
        public static PRO_ProgramDAL dbProgram=new PRO_ProgramDAL();
        public static SEC_UserDAL dbUser = new SEC_UserDAL();
        public static PRO_ProgramSolutionDAL dbSolution= new PRO_ProgramSolutionDAL();
        public static PRO_ProgramTestCaseDAL dbProgramTestCase = new PRO_ProgramTestCaseDAL();

    }
}
