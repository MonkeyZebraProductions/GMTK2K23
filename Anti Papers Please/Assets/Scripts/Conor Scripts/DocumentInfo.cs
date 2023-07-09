using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DocumentInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text NameField, DOBField, ExpiryDateField, PassportNoField, VehicleRegField, IDNoField;
    public string Name, DOB, ExpiryDate, PassportNo, VehicleReg, IDNo;
    [SerializeField] private TMP_Dropdown Birthplace,VehicleType;
    public int BirthplaceValue, VehicleValue;
    [SerializeField] private GameObject PhotoSlot;
    public GameObject PhotoChild;
    public int DocumentType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Name = NameField.text;
        if(DOBField !=null)
        {
            DOB = DOBField.text;
        }

        if (ExpiryDateField != null)
        {
            ExpiryDate = ExpiryDateField.text;
        }

        if (PassportNoField != null)
        {
            PassportNo = PassportNoField.text;
        }

        if (VehicleRegField != null)
        {
            VehicleReg = VehicleRegField.text;
        }

        if (IDNoField != null)
        {
            IDNo = IDNoField.text;
        }

        if (Birthplace != null)
        {
            BirthplaceValue = Birthplace.value;
        }

        if (VehicleType != null)
        {
            VehicleValue = VehicleType.value;
        }

        if (PhotoSlot != null)
        {
            PhotoChild = PhotoSlot.transform.GetChild(0).gameObject;
        }

        
    }
}
