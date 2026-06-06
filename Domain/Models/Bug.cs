using Domain.Enums;

namespace Domain.Models;

public class Bug {
    // https://www.w3schools.com/cs/cs_properties.php
    // https://stackoverflow.com/questions/3847832/understanding-private-setters
    // https://dev.to/mashrulhaque/how-to-design-a-maintainable-net-solution-structure-for-growing-teams-284n
    private int _id;

    public int Id {
        get { return _id; }
        private set { _id = value; }
    }

    private string _title;

    public string Title {
        get { return _title; }
        set { _title = value; }
    }

    private string _description;

    public string Description {
        get { return _description; }
        set { _description = value; }
    }


    private BugStatus _status;

    public BugStatus Status {
        get { return _status; }
        set { _status = value; }
    }


    public Bug(string title, string description) {
        Title = title;
        Description = description;
        Status = BugStatus.Open;
    }
}