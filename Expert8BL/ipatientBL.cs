using Expert8Model;

namespace expert8BL
{
    public interface ipatientBL
    {
        void addpatient (Patient p_patient);

        Patient searchpatientbyemailandpassword(string p_email, string p_password);

        List<Patient> GetAllPatients();
    }
}
