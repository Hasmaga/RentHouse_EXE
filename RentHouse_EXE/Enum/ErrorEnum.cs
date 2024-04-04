namespace RentHouse_EXE.Enum
{
    public class AccountErrorEnum
    {
        public const string UPDATE_ACCOUNT_ERROR = "UPDATE_ACCOUNT_ERROR";
        public const string ACCOUNT_NOT_FOUND = "ACCOUNT_NOT_FOUND";
        public const string ACCOUNT_IS_EXIST = "ACCOUNT_IS_EXIST";
        public const string CREATE_ACCOUNT_FAILED = "CREATE_ACCOUNT_FAILED";
        public const string LOGIN_FAILED = "LOGIN_FAILED";
        public const string UPDATE_ACCOUNT_FAILED = "UPDATE_ACCOUNT_FAILED";
    }

    public class StatusErrorEnum
    {
        public const string LIST_STATUS_EMPTY = "LIST_STATUS_EMPTY";
        public const string UPDATE_STATUS_ERROR = "UPDATE_STATUS_ERROR";
        public const string STATUS_NOT_FOUND = "STATUS_NOT_FOUND";
        public const string CREATE_STATUS_ERROR = "CREATE_STATUS_ERROR";
        public const string STATUS_EXIST = "STATUS_EXIST";
    }

    public class RoleErrorEnum
    {
        public const string ROLE_IS_EXIST = "ROLE_IS_EXIST";
        public const string CREATE_ROLE_FAILED = "CREATE_ROLE_FAILED";
        public const string LIST_ROLE_EMPTY = "LIST_ROLE_EMPTY";
        public const string ROLE_NOT_FOUND = "ROLE_NOT_FOUND";
        public const string UPDATE_ROLE_FAILED = "UPDATE_ROLE_FAILED";
    }

    public class ServerErrorEnum
    {
        public const string SERVER_ERROR = "SERVER_ERROR";
    }
}
