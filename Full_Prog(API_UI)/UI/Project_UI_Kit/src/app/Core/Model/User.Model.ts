// بسم الله الرحمن الرحيم



export interface User{
    FirstName: string,
    MiddleName: string,
    LastName: string,
    BirthDate: Date,
    MobileNumber: string,
    Email: string,
    
    Addresses: [
        {
        Governorate: string,
        City: string,
        Street: string,
        BuildingNumber: string,
        FlatNumber: number
        }
    ]

}