using System.ComponentModel.DataAnnotations;

namespace Expert8Model;
public class Patient
{
    private int _pId;

    public int PID { 
        get {return _pId; } 
        set {
            if (value >= 0)
            {
                _pId = value;
            }
            else
            {
                throw new ValidationException("PID is not valid");
            }
        } 
    }

    private string _pFirstName { get; set; }

    public string FirstName { 
        get {return _pFirstName; }
        set {
            if (value.Length <= 50)
            {
                _pFirstName = value;
            }
            else
            {
                throw new ValidationException("First Name is Too Long; not valid");
            }
        } 
    } 

    private string _pLastName { get; set; }

    public string LastName { 
        get {return _pLastName; }
        set {
            if (value.Length <= 50)
            {
                _pLastName = value;
            }
            else
            {
                throw new ValidationException("Last Name is Too Long; not valid");
            }
        } 
    } 

    private string _pEmail { get; set; }

    public string Email { 
        get {return _pEmail; }
        set {
            if (value.Length <= 50)
            {
                _pEmail = value;
            }
            else
            {
                throw new ValidationException("Email is Too Long; not valid");
            }
        } 
    }

    private string _pPhone { get; set; }

    public string Phone { 
        get {return _pPhone;} 
        set {
            if (value.Length == 10)
            {
                _pPhone = value;
            }
            else
            {
                throw new ValidationException("Phone number is not valid");
            }
        } 
    }

    private string _pAddress { get; set; }

    public string Address { 
        get {return _pAddress; }
        set {
            if (value.Length <= 50)
            {
                _pAddress = value;
            }
            else
            {
                throw new ValidationException("Address is Too Long; not valid");
            }
        } 
    }

    private string _pCity { get; set; }

    public string City { 
        get {return _pCity; }
        set {
            if (value.Length <= 50)
            {
                _pCity = value;
            }
            else
            {
                throw new ValidationException("City's name is Too Long; not valid");
            }
        } 
    }

    private string _pState { get; set; }

    public string State { 
        get {return _pState; }
        set {
            if (value.Length <= 20)
            {
                _pState = value;
            }
            else
            {
                throw new ValidationException("State's name is Too Long; not valid");
            }
        } 
    }

    private string _pZip { get; set; }

    public string Zip { 
        get {return _pZip; }
        set {
            if (value.Length == 5)
            {
                _pZip = value;
            }
            else
            {
                throw new ValidationException("Zip code is not 5 digits long; not valid");
            }
        } 
    }

    private string _pPassword { get; set; }

    public string Password { 
        get {return _pPassword; }
        set {
            if (value.Length <= 20)
            {
                _pPassword = value;
            }
            else
            {
                throw new ValidationException("Name is Too Long; not valid");
            }
        } 
    }

    public List<Service> Services { get; set; }
}
