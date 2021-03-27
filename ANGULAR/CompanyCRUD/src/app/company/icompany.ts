export class Company {
    public id: number;
    public email: string;
    public name:string;
    public totalEmployee:number;
    public address:string;
    public isCompanyActive:boolean;
    public totalBranch:number;
    public companyBranch:CompanyBranch[]
    
    /**
     *
     */
    constructor(id: number,email: string,name:string, totalEmployee:number,address:string,isCompanyActive:boolean,totalBranch:number) {
       this.id = id;
       this.email=email;
       this.name=name;
       this.totalEmployee=totalEmployee;
       this.address=address;
       this.isCompanyActive=isCompanyActive;
       this.totalBranch=totalBranch;
       this.companyBranch=[];
    }
}

export class CompanyBranch{
    
    public branchId: number;
    public branchName: string;
    public branchAddress: string;
    constructor(branchId: number, branchName: string,branchAddress:string ){ 
        this.branchId = branchId;
        this.branchName = branchName;
        this.branchAddress = branchAddress;
    }
}
