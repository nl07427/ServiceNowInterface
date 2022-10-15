function Get-SnowBusinessUnit {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.BusinessUnits() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
} 

function New-SnowBusinessUnit {
    param (
        [parameter(Mandatory = $true)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$BuHead,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$SysDomain,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [string]$Parent
    )
    $parameters = $MyInvocation.BoundParameters  
    $bu = New-Object -TypeName ServiceNow.Graph.Models.BusinessUnit
    $bu.Name = $Name
    if ($parameters.ContainsKey("BuHead") -and $BuHead) {
        $bu.BuHead = Get-ReferenceLink $BuHead
    }    
    if ($parameters.ContainsKey("Company") -and $Company) {
        $bu.Company = Get-ReferenceLink $Company
    }        
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $bu.Parent = Get-ReferenceLink $Parent
    }            
    if ($parameters.ContainsKey("Description")) {
        $bu.Description = $Description
    }
    if ($parameters.ContainsKey("SysDomain") -and $SysDomain) {
        $bu.SysDomain = Get-ReferenceLink $SysDomain
    }            
    $ServiceNowClient.BusinessUnits().Request().AddAsync($bu).GetAwaiter().GetResult()
}         

function Set-SnowBusinessUnit {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$BuHead,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [string]$Parent
    )
   
    $businessUnitBuilder = $ServiceNowClient.BusinessUnits()[$Id] 
    $parameters = $MyInvocation.BoundParameters  
    $bu = New-Object -TypeName ServiceNow.Graph.Models.BusinessUnit
    $bu.Id = $Id

    if ($parameters.ContainsKey("BuHead")) {
        if($BuHead) {
            $bu.BuHead = Get-ReferenceLink $BuHead
        } else {
            $bu.BuHead =  Get-ReferenceLink  ""
        }
    }    

    if ($parameters.ContainsKey("Company")) {
        if($Company) {
            $bu.Company = Get-ReferenceLink $Company
        } else {
            $bu.Company =  Get-ReferenceLink  ""
        }
    }        

    if ($parameters.ContainsKey("Parent")) {
        if($Parent) {
            $bu.Parent = Get-ReferenceLink $Parent
        } else {
            $bu.Parent =  Get-ReferenceLink  ""
        }
    }        
        
    if ($parameters.ContainsKey("Description")) {
        $bu.Description = $Description
    }
    if ($parameters.ContainsKey("Name")) {
        $bu.Name = $Name
    }
    $businessUnitBuilder.Request().UpdateAsync($bu).GetAwaiter().GetResult()
}        

function Get-SnowBuilding {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy,

        [parameter(Mandatory = $false)]
        [String]$Version=""        
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Buildings($Version) -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
} 

function New-SnowBuilding {
    param (
        [parameter(Mandatory = $true)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Contact,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$Notes,

        [parameter(Mandatory = $false)]
        [int]$Floors
    )
    $parameters = $MyInvocation.BoundParameters  
    $building = New-Object -TypeName ServiceNow.Graph.Models.Building
    $building.Name = $Name
    if ($parameters.ContainsKey("Contact") -and $Contact) {
        $building.Contact = Get-ReferenceLink $Contact
    }    
    if ($parameters.ContainsKey("Location") -and $Location) {
        $building.Location = Get-ReferenceLink $Location
    }        
    if ($parameters.ContainsKey("Notes")) {
        $building.Notes = $Notes
    }
    if ($parameters.ContainsKey("Floors")) {
        $building.Floors = $Floors
    }    
    $ServiceNowClient.Buildings().Request().AddAsync($building).GetAwaiter().GetResult()
}         

function Set-SnowBuilding {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Contact,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$Notes,

        [parameter(Mandatory = $false)]
        [int]$Floors
    )
   
    $buildingBuilder = $ServiceNowClient.Buildings()[$Id] 
    $parameters = $MyInvocation.BoundParameters  
    $building = New-Object -TypeName ServiceNow.Graph.Models.Building
    $building.Id = $Id
    if ($parameters.ContainsKey("Contact")) {
        if($Contact) {
            $building.Contact = Get-ReferenceLink $Contact
        } else {
            $building.Contact =  Get-ReferenceLink  ""
        }
    }    

    if ($parameters.ContainsKey("Location")) {
        if($Location) {
            $building.Location = Get-ReferenceLink $Location
        } else {
            $building.Location =  Get-ReferenceLink  ""
        }
    }    

    if ($parameters.ContainsKey("Notes")) {
        $building.Notes = $Notes
    }
    if ($parameters.ContainsKey("Floors")) {
        $building.Floors = $Floors
    }    
    if ($parameters.ContainsKey("Name")) {
        $building.Name = $Name
    }
    $buildingBuilder.Request().UpdateAsync($building).GetAwaiter().GetResult()
}        

function Get-SnowConfigurationItem {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.ConfigurationItems() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}      

function Get-SnowCostCenter {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.CostCenters() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                            

function New-SnowCostCenter {
    param (
        [parameter(Mandatory = $false)]
        [string]$AccountNumber,

        [parameter(Mandatory = $false)]
        [string]$Code,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$Manager,

        [parameter(Mandatory = $true)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$SysDomain,

        [parameter(Mandatory = $false)]
        [string]$ValidFrom,

        [parameter(Mandatory = $false)]
        [string]$ValidTo        
    )
    $parameters = $MyInvocation.BoundParameters  
    $costcenter = New-Object -TypeName ServiceNow.Graph.Models.CostCenter
    $costcenter.Name = $Name
    if ($parameters.ContainsKey("AccountNumber")) {
        $costcenter.AccountNumber = $AccountNumber
    }
    if ($parameters.ContainsKey("Code")) {
        $costcenter.Code = $Code
    }        
    if ($parameters.ContainsKey("Location") -and $Location) {
        $costcenter.Location = Get-ReferenceLink $Location
    }    
    if ($parameters.ContainsKey("Manager") -and $Manager) {
        $costcenter.Manager = Get-ReferenceLink $Manager
    }        
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $costcenter.Parent = Get-ReferenceLink $Parent
    }        
    if ($parameters.ContainsKey("SysDomain") -and $SysDomain) {
        $costcenter.SysDomain = Get-ReferenceLink $SysDomain
    }            
    if ($parameters.ContainsKey("ValidFrom") -and $ValidFrom) {
        $costcenter.ValidFrom = $ValidFrom
    }                     

    if ($parameters.ContainsKey("ValidTo") -and $ValidTo) {
        $costcenter.ValidTo = $ValidTo
    }                     

    $ServiceNowClient.CostCenters().Request().AddAsync($costcenter).GetAwaiter().GetResult()
}         

function Set-SnowCostCenter {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$AccountNumber,

        [parameter(Mandatory = $false)]
        [string]$Code,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$Manager,

        [parameter(Mandatory = $false)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$ValidFrom,

        [parameter(Mandatory = $false)]
        [string]$ValidTo        
    )
   
    $costCenterBuilder = $ServiceNowClient.CostCenters()[$Id] 
    $parameters = $MyInvocation.BoundParameters  
    $costcenter = New-Object -TypeName ServiceNow.Graph.Models.CostCenter
    $costcenter.Id = $Id

    if ($parameters.ContainsKey("AccountNumber")) {
        $costcenter.AccountNumber = $AccountNumber
    }
    if ($parameters.ContainsKey("Code")) {
        $costcenter.Code = $Code
    }        
    if ($parameters.ContainsKey("Location") ) {
        if($Location) {
            $costcenter.Location = Get-ReferenceLink $Location
        } else {
            $costcenter.Location = Get-ReferenceLink ""
        }
    }    
    if ($parameters.ContainsKey("Manager") ) {
        if($Manager) {
            $costcenter.Manager = Get-ReferenceLink $Manager
        } else {
            $costcenter.Manager = Get-ReferenceLink ""
        }
    }        
    if ($parameters.ContainsKey("Name")) {
        $costcenter.Name = $Name
    }            
    if ($parameters.ContainsKey("Parent") ) {
        if($Parent) {
            $costcenter.Parent = Get-ReferenceLink $Parent
        } else {
            $costcenter.Parent = Get-ReferenceLink ""
        }
    }
    if ($parameters.ContainsKey("ValidFrom")) {
        $costcenter.ValidFrom = $ValidFrom
    }                     

    if ($parameters.ContainsKey("ValidTo")) {
        $costcenter.ValidTo = $ValidTo
    }                     

    $costCenterBuilder.Request().UpdateAsync($costcenter).GetAwaiter().GetResult()
}        

function Get-SnowDepartment {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Departments() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                            

function New-SnowDepartment {
    param (
        [parameter(Mandatory = $false)]
        [string]$BusinessUnit,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$CostCenter,

        [parameter(Mandatory = $false)]
        [string]$DeptHead,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [int]$HeadCount,

        [parameter(Mandatory = $false)]
        [string]$DepartmentId,

        [parameter(Mandatory = $true)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$PrimaryContact        
    )
    $parameters = $MyInvocation.BoundParameters  
    $department = New-Object -TypeName ServiceNow.Graph.Models.Department
    $department.Name = $Name
    if ($parameters.ContainsKey("BusinessUnit") -and $BusinessUnit) {
        $department.BusinessUnit = Get-ReferenceLink $BusinessUnit
    }        
    if ($parameters.ContainsKey("Company") -and $Company) {
        $department.Company = Get-ReferenceLink $Company
    }            
    if ($parameters.ContainsKey("CostCenter") -and $CostCenter) {
        $department.CostCenter = Get-ReferenceLink $CostCenter
    }                
    if ($parameters.ContainsKey("DeptHead") -and $DeptHead) {
        $department.DeptHead = Get-ReferenceLink $DeptHead
    }                    
    if ($parameters.ContainsKey("Description")) {
        $department.Description = $Description
    }
    if ($parameters.ContainsKey("HeadCount")) {
        $department.HeadCount = $HeadCount
    }        
    if ($parameters.ContainsKey("DepartmentId")) {
        $department.DepartmentId = $DepartmentId
    }            
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $department.Parent = Get-ReferenceLink $Parent
    }    
    if ($parameters.ContainsKey("PrimaryContact") -and $PrimaryContact) {
        $department.PrimaryContact = Get-ReferenceLink $PrimaryContact
    }        

    $ServiceNowClient.Departments().Request().AddAsync($department).GetAwaiter().GetResult()
}         

function Set-SnowDepartment {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$BusinessUnit,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$CostCenter,

        [parameter(Mandatory = $false)]
        [string]$DeptHead,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [int]$HeadCount,

        [parameter(Mandatory = $false)]
        [string]$DepartmentId,

        [parameter(Mandatory = $false)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$PrimaryContact        
    )
   
    $departmentBuilder = $ServiceNowClient.Departments()[$Id] 
    $parameters = $MyInvocation.BoundParameters  
    $department = New-Object -TypeName ServiceNow.Graph.Models.Department
    $department.Id = $Id

    if ($parameters.ContainsKey("BusinessUnit")) {
        if($BusinessUnit){
            $department.BusinessUnit = Get-ReferenceLink $BusinessUnit
        } else {
            $department.BusinessUnit = Get-ReferenceLink ""
        }
    }        
    if ($parameters.ContainsKey("Company")) {
        if($Company){
            $department.Company = Get-ReferenceLink $Company
        } else {
            $department.Company = Get-ReferenceLink ""
        }
    }            
    if ($parameters.ContainsKey("CostCenter")) {
        if($CostCenter){
            $department.CostCenter = Get-ReferenceLink $CostCenter
        } else {
            $department.CostCenter = Get-ReferenceLink ""
        }
    }                
    if ($parameters.ContainsKey("DeptHead")) {
        if($DeptHead){
            $department.DeptHead = Get-ReferenceLink $DeptHead
        } else {
            $department.DeptHead = Get-ReferenceLink ""
        }
    }                    
    if ($parameters.ContainsKey("Description")) {
        $department.Description = $Description
    }
    if ($parameters.ContainsKey("HeadCount")) {
        $department.HeadCount = $HeadCount
    }        
    if ($parameters.ContainsKey("DepartmentId")) {
        $department.DepartmentId = $DepartmentId
    }            
    if ($parameters.ContainsKey("Name")) {
        $department.Name = $Name
    }              
    if ($parameters.ContainsKey("Parent")) {
        if($Parent){
            $department.Parent = Get-ReferenceLink $Parent
        } else {
            $department.Parent = Get-ReferenceLink ""
        }
    }              
    if ($parameters.ContainsKey("PrimaryContact")) {
        if($PrimaryContact){
            $department.PrimaryContact = Get-ReferenceLink $PrimaryContact
        } else {
            $department.PrimaryContact = Get-ReferenceLink ""
        }
    }             

    $departmentBuilder.Request().UpdateAsync($department).GetAwaiter().GetResult()
}        

function Get-SnowLocation {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Locations() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}        

function New-SnowLocation {
    param (
        [parameter(Mandatory = $false)]
        [string]$City,

        [parameter(Mandatory = $false)]
        [string]$CmnLocationSource,

        [parameter(Mandatory = $false)]
        [string]$CmnLocationType,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$Contact,

        [parameter(Mandatory = $false)]
        [string]$CoordinatesRetrievedOn,

        [parameter(Mandatory = $false)]
        [string]$Country,

        [parameter(Mandatory = $false)]
        [bool]$Duplicate,

        [parameter(Mandatory = $false)]
        [string]$FaxPhone,

        [parameter(Mandatory = $false)]
        [string]$FullName,        

        [parameter(Mandatory = $false)]
        [string]$Latitude,

        [parameter(Mandatory = $false)]
        [string]$LatLongError,

        [parameter(Mandatory = $false)]
        [string]$LifeCycleStage,

        [parameter(Mandatory = $false)]
        [string]$LifeCycleStageStatus,        

        [parameter(Mandatory = $false)]
        [string]$Longitude,

        [parameter(Mandatory = $false)]
        [string]$ManagedByGroup,

        [parameter(Mandatory = $true)]
        [string]$Name,        

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$Phone,        

        [parameter(Mandatory = $false)]
        [string]$PhoneTerritory,

        [parameter(Mandatory = $false)]
        [string]$PrimaryLocation,

        [parameter(Mandatory = $false)]
        [string]$State,

        [parameter(Mandatory = $false)]
        [bool]$StockRoom,        

        [parameter(Mandatory = $false)]
        [string]$Street,

        [parameter(Mandatory = $false)]
        [string]$TimeZone,
        
        [parameter(Mandatory = $false)]
        [string]$Zip        
    )
    $parameters = $MyInvocation.BoundParameters  
    $location = New-Object -TypeName ServiceNow.Graph.Models.Location
    $location.Name = $Name
    if ($parameters.ContainsKey("City")) {
        $location.City = $City
    }
    if ($parameters.ContainsKey("CmnLocationSource")) {
        $location.CmnLocationSource = $CmnLocationSource
    }
    if ($parameters.ContainsKey("CmnLocationType")) {
        $location.CmnLocationType = $CmnLocationType
    }            
    if ($parameters.ContainsKey("Company") -and $Company) {
        $location.Company = Get-ReferenceLink $Company
    }        
    if ($parameters.ContainsKey("Contact") -and $Contact) {
        $location.Contact = Get-ReferenceLink $Contact
    }        
    if ($parameters.ContainsKey("CoordinatesRetrievedOn")) {
        $location.CoordinatesRetrievedOn = $CoordinatesRetrievedOn
    }                 
    if ($parameters.ContainsKey("Country")) {
        $location.Country = $Country
    }                
    if ($parameters.ContainsKey("Duplicate")) {
        $location.Duplicate = $Duplicate
    }                
    if ($parameters.ContainsKey("FaxPhone")) {
        $location.FaxPhone = $FaxPhone
    }                
    if ($parameters.ContainsKey("FullName")) {
        $location.FullName = $FullName
    }                
    if ($parameters.ContainsKey("Latitude")) {
        $location.Latitude = $Latitude
    }                
    if ($parameters.ContainsKey("LatLongError")) {
        $location.LatLongError = $LatLongError
    }                
    if ($parameters.ContainsKey("LifeCycleStage") -and $LifeCycleStage) {
        $location.LifeCycleStage = Get-ReferenceLink $LifeCycleStage
    }                
    if ($parameters.ContainsKey("LifeCycleStageStatus") -and $LifeCycleStageStatus) {
        $location.LifeCycleStageStatus = Get-ReferenceLink $LifeCycleStageStatus
    }                    
    if ($parameters.ContainsKey("Longitude")) {
        $location.Longitude = $Longitude
    }
    if ($parameters.ContainsKey("ManagedByGroup") -and $ManagedByGroup) {
        $location.ManagedByGroup = Get-ReferenceLink $ManagedByGroup
    }        
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $location.Parent = Get-ReferenceLink $Parent
    }        
    if ($parameters.ContainsKey("Phone")) {
        $location.Phone = $Phone
    }                
    if ($parameters.ContainsKey("PhoneTerritory") -and $PhoneTerritory) {
        $location.PhoneTerritory = Get-ReferenceLink $PhoneTerritory
    }                
    if ($parameters.ContainsKey("PrimaryLocation") -and $PrimaryLocation) {
        $location.PrimaryLocation = Get-ReferenceLink $PrimaryLocation
    }            
    if ($parameters.ContainsKey("State")) {
        $location.State = $State
    }        
    if ($parameters.ContainsKey("StockRoom")) {
        $location.StockRoom = $StockRoom
    }        
    if ($parameters.ContainsKey("Street")) {
        $location.Street = $Street
    }        
    if ($parameters.ContainsKey("TimeZone")) {
        $location.TimeZone = $TimeZone
    }        
    if ($parameters.ContainsKey("Zip")) {
        $location.Zip = $Zip
    }        

    $ServiceNowClient.Locations().Request().AddAsync($location).GetAwaiter().GetResult()
}         

function Set-SnowLocation {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$City,

        [parameter(Mandatory = $false)]
        [string]$CmnLocationSource,

        [parameter(Mandatory = $false)]
        [string]$CmnLocationType,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$Contact,

        [parameter(Mandatory = $false)]
        [string]$CoordinatesRetrievedOn,

        [parameter(Mandatory = $false)]
        [string]$Country,

        [parameter(Mandatory = $false)]
        [bool]$Duplicate,

        [parameter(Mandatory = $false)]
        [string]$FaxPhone,

        [parameter(Mandatory = $false)]
        [string]$FullName,        

        [parameter(Mandatory = $false)]
        [string]$Latitude,

        [parameter(Mandatory = $false)]
        [string]$LatLongError,

        [parameter(Mandatory = $false)]
        [string]$LifeCycleStage,

        [parameter(Mandatory = $false)]
        [string]$LifeCycleStageStatus,        

        [parameter(Mandatory = $false)]
        [string]$Longitude,

        [parameter(Mandatory = $false)]
        [string]$ManagedByGroup,

        [parameter(Mandatory = $false)]
        [string]$Name,        

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$Phone,        

        [parameter(Mandatory = $false)]
        [string]$PhoneTerritory,

        [parameter(Mandatory = $false)]
        [string]$PrimaryLocation,

        [parameter(Mandatory = $false)]
        [string]$State,

        [parameter(Mandatory = $false)]
        [bool]$StockRoom,        

        [parameter(Mandatory = $false)]
        [string]$Street,

        [parameter(Mandatory = $false)]
        [string]$TimeZone,
        
        [parameter(Mandatory = $false)]
        [string]$Zip        
    )
   
    $locationBuilder = $ServiceNowClient.Locations()[$Id] 
    $parameters = $MyInvocation.BoundParameters  
    $location = New-Object -TypeName ServiceNow.Graph.Models.Location
    $location.Id = $Id

    if ($parameters.ContainsKey("City")) {
        $location.City = $City
    }
    if ($parameters.ContainsKey("CmnLocationSource")) {
        $location.CmnLocationSource = $CmnLocationSource
    }
    if ($parameters.ContainsKey("CmnLocationType")) {
        $location.CmnLocationType = $CmnLocationType
    }            
    if ($parameters.ContainsKey("Company")) {
        if ($Company) {
            $location.Company = Get-ReferenceLink $Company
        } else {
            $location.Company = Get-ReferenceLink ""
        }
    }        
    if ($parameters.ContainsKey("Contact")) {
        if ($Contact) {
            $location.Contact = Get-ReferenceLink $Contact
        } else {
            $location.Contact = Get-ReferenceLink ""
        }
    }            
    if ($parameters.ContainsKey("CoordinatesRetrievedOn")) {
        $location.CoordinatesRetrievedOn = $CoordinatesRetrievedOn
    }                 
    if ($parameters.ContainsKey("Country")) {
        $location.Country = $Country
    }                
    if ($parameters.ContainsKey("Duplicate")) {
        $location.Duplicate = $Duplicate
    }                
    if ($parameters.ContainsKey("FaxPhone")) {
        $location.FaxPhone = $FaxPhone
    }                
    if ($parameters.ContainsKey("FullName")) {
        $location.FullName = $FullName
    }                
    if ($parameters.ContainsKey("Latitude")) {
        $location.Latitude = $Latitude
    }                
    if ($parameters.ContainsKey("LatLongError")) {
        $location.LatLongError = $LatLongError
    }          
    if ($parameters.ContainsKey("LifeCycleStage")) {
        if ($LifeCycleStage) {
            $location.LifeCycleStage = Get-ReferenceLink $LifeCycleStage
        } else {
            $location.LifeCycleStage = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("LifeCycleStageStatus")) {
        if ($LifeCycleStageStatus) {
            $location.LifeCycleStageStatus = Get-ReferenceLink $LifeCycleStageStatus
        } else {
            $location.LifeCycleStageStatus = Get-ReferenceLink ""
        }
    }                          
    if ($parameters.ContainsKey("Longitude")) {
        $location.Longitude = $Longitude
    }
    if ($parameters.ContainsKey("ManagedByGroup")) {
        if ($ManagedByGroup) {
            $location.ManagedByGroup = Get-ReferenceLink $ManagedByGroup
        } else {
            $location.ManagedByGroup = Get-ReferenceLink ""
        }
    }            
    if ($parameters.ContainsKey("Parent")) {
        if ($Parent) {
            $location.Parent = Get-ReferenceLink $Parent
        } else {
            $location.Parent = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Phone")) {
        $location.Phone = $Phone
    }            
    if ($parameters.ContainsKey("PhoneTerritory")) {
        if ($PhoneTerritory) {
            $location.PhoneTerritory = Get-ReferenceLink $PhoneTerritory
        } else {
            $location.PhoneTerritory = Get-ReferenceLink ""
        }
    }                    
    if ($parameters.ContainsKey("PrimaryLocation")) {
        if ($PrimaryLocation) {
            $location.PrimaryLocation = Get-ReferenceLink $PrimaryLocation
        } else {
            $location.PrimaryLocation = Get-ReferenceLink ""
        }
    }                   
    if ($parameters.ContainsKey("State")) {
        $location.State = $State
    }        
    if ($parameters.ContainsKey("StockRoom")) {
        $location.StockRoom = $StockRoom
    }        
    if ($parameters.ContainsKey("Street")) {
        $location.Street = $Street
    }        
    if ($parameters.ContainsKey("TimeZone")) {
        $location.TimeZone = $TimeZone
    }        
    if ($parameters.ContainsKey("Zip")) {
        $location.Zip = $Zip
    }        
    if ($parameters.ContainsKey("Name")) {
        $location.Name = $Name
    }        

    $locationBuilder.Request().UpdateAsync($location).GetAwaiter().GetResult()
}        

function Get-SnowCompany {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Companies() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                                

function New-SnowCompany {
    param (
        [parameter(Mandatory = $false)]
        [string]$AppleIcon,

        [parameter(Mandatory = $false)]
        [string]$BannerImage,

        [parameter(Mandatory = $false)]
        [string]$BannerImageLight,

        [parameter(Mandatory = $false)]
        [string]$BannerText,

        [parameter(Mandatory = $false)]
        [string]$City,

        [parameter(Mandatory = $false)]
        [string]$Contact,

        [parameter(Mandatory = $false)]
        [string]$CoordinatesRetrievedOn,

        [parameter(Mandatory = $false)]
        [string]$Country,

        [parameter(Mandatory = $false)]
        [bool]$Customer,

        [parameter(Mandatory = $false)]
        [string]$Discount,        

        [parameter(Mandatory = $false)]
        [string]$FaxPhone,

        [parameter(Mandatory = $false)]
        [string]$FiscalYear,

        [parameter(Mandatory = $false)]
        [string]$Latitude,

        [parameter(Mandatory = $false)]
        [string]$LatLongError,        

        [parameter(Mandatory = $false)]
        [string]$Longitude,

        [parameter(Mandatory = $false)]
        [bool]$Manufacturer,

        [parameter(Mandatory = $false)]
        [string]$MarketCap,        

        [parameter(Mandatory = $true)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Notes,        

        [parameter(Mandatory = $false)]
        [int]$NumEmployees,

        [parameter(Mandatory = $false)]
        [string]$PrimaryLocation,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$Phone,        

        [parameter(Mandatory = $false)]
        [bool]$Primary,

        [parameter(Mandatory = $false)]
        [string]$Profits,
        
        [parameter(Mandatory = $false)]
        [bool]$PubliclyTraded,

        [parameter(Mandatory = $false)]
        [string]$RankTier,

        [parameter(Mandatory = $false)]
        [string]$RevenuePerYear,

        [parameter(Mandatory = $false)]
        [string]$State,        

        [parameter(Mandatory = $false)]
        [string]$StockPrice,

        [parameter(Mandatory = $false)]
        [string]$StockSymbol,

        [parameter(Mandatory = $false)]
        [string]$Street,
        
        [parameter(Mandatory = $false)]
        [string]$Theme,

        [parameter(Mandatory = $false)]
        [bool]$Vendor,

        [parameter(Mandatory = $false)]
        [string]$VendorManager,

        [parameter(Mandatory = $false)]
        [string]$VendorType,        

        [parameter(Mandatory = $false)]
        [string]$Website,

        [parameter(Mandatory = $false)]
        [string]$Zip        
    )
    $parameters = $MyInvocation.BoundParameters  
    $company = New-Object -TypeName ServiceNow.Graph.Models.Company
    $company.Name = $Name
    if ($parameters.ContainsKey("AppleIcon")) {
        $company.AppleIcon = $AppleIcon
    }
    if ($parameters.ContainsKey("BannerImage")) {
        $company.BannerImage = $BannerImage
    }
    if ($parameters.ContainsKey("BannerImageLight")) {
        $company.BannerImageLight = $BannerImageLight
    }            
    if ($parameters.ContainsKey("BannerText")) {
        $company.BannerText = $BannerText
    }            
    if ($parameters.ContainsKey("City")) {
        $company.City = $City
    }            
    if ($parameters.ContainsKey("Contact") -and $Contact) {
        $company.Contact = Get-ReferenceLink $Contact
    }        
    if ($parameters.ContainsKey("CoordinatesRetrievedOn")) {
        $company.CoordinatesRetrievedOn = $CoordinatesRetrievedOn
    }                 
    if ($parameters.ContainsKey("Country")) {
        $company.Country = $Country
    }                
    if ($parameters.ContainsKey("Customer")) {
        $company.Customer = $Customer
    }                
    if ($parameters.ContainsKey("FaxPhone")) {
        $company.FaxPhone = $FaxPhone
    }                
    if ($parameters.ContainsKey("Discount")) {
        $company.Discount = $Discount
    }                
    if ($parameters.ContainsKey("FaxPhone")) {
        $company.FaxPhone = $FaxPhone
    }                
    if ($parameters.ContainsKey("FiscalYear")) {
        $company.FiscalYear = $FiscalYear
    }                 
    if ($parameters.ContainsKey("Latitude")) {
        $company.Latitude = $Latitude
    }                
    if ($parameters.ContainsKey("LatLongError")) {
        $company.LatLongError = $LatLongError
    }                
    if ($parameters.ContainsKey("Longitude")) {
        $company.Longitude = $Longitude
    }    
    if ($parameters.ContainsKey("Manufacturer")) {
        $company.Manufacturer = $Manufacturer
    }    
    if ($parameters.ContainsKey("MarketCap")) {
        $company.MarketCap = $MarketCap
    }    
    if ($parameters.ContainsKey("Notes")) {
        $company.Notes = $Notes
    }    
    if ($parameters.ContainsKey("NumEmployees")) {
        $company.NumEmployees = $NumEmployees
    }    
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $company.Parent = Get-ReferenceLink $Parent
    }                
    if ($parameters.ContainsKey("Phone")) {
        $company.Phone = $Phone
    }                
    if ($parameters.ContainsKey("Primary")) {
        $company.Primary = $Primary
    }                
    if ($parameters.ContainsKey("Profits")) {
        $company.Profits = $Profits
    }                
    if ($parameters.ContainsKey("PubliclyTraded")) {
        $company.PubliclyTraded = $PubliclyTraded
    }                
    if ($parameters.ContainsKey("RankTier")) {
        $company.RankTier = $RankTier
    }                
    if ($parameters.ContainsKey("RevenuePerYear")) {
        $company.RevenuePerYear = $RevenuePerYear
    }                
    if ($parameters.ContainsKey("State")) {
        $company.State = $State
    }                
    if ($parameters.ContainsKey("StockPrice")) {
        $company.StockPrice = $StockPrice
    }                
    if ($parameters.ContainsKey("StockSymbol")) {
        $company.StockSymbol = $StockSymbol
    }                
    if ($parameters.ContainsKey("Street")) {
        $company.Street = $Street
    }                
    if ($parameters.ContainsKey("Theme") -and $Theme) {
        $company.Theme = Get-ReferenceLink $Theme
    }                
    if ($parameters.ContainsKey("Vendor")) {
        $company.Vendor = $Vendor
    }                    
    if ($parameters.ContainsKey("VendorManager")) {
        $company.VendorManager = $VendorManager
    }                    
    if ($parameters.ContainsKey("VendorType")) {
        $company.VendorType = $VendorType
    }                    
    if ($parameters.ContainsKey("Website")) {
        $company.Website = $Website
    }                    
    if ($parameters.ContainsKey("Zip")) {
        $company.Zip = $Zip
    }        

    $ServiceNowClient.Companies().Request().AddAsync($company).GetAwaiter().GetResult()
}         

function Set-SnowCompany {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$AppleIcon,

        [parameter(Mandatory = $false)]
        [string]$BannerImage,

        [parameter(Mandatory = $false)]
        [string]$BannerImageLight,

        [parameter(Mandatory = $false)]
        [string]$BannerText,

        [parameter(Mandatory = $false)]
        [string]$City,

        [parameter(Mandatory = $false)]
        [string]$Contact,

        [parameter(Mandatory = $false)]
        [string]$CoordinatesRetrievedOn,

        [parameter(Mandatory = $false)]
        [string]$Country,

        [parameter(Mandatory = $false)]
        [bool]$Customer,

        [parameter(Mandatory = $false)]
        [string]$Discount,        

        [parameter(Mandatory = $false)]
        [string]$FaxPhone,

        [parameter(Mandatory = $false)]
        [string]$FiscalYear,

        [parameter(Mandatory = $false)]
        [string]$Latitude,

        [parameter(Mandatory = $false)]
        [string]$LatLongError,        

        [parameter(Mandatory = $false)]
        [string]$Longitude,

        [parameter(Mandatory = $false)]
        [bool]$Manufacturer,

        [parameter(Mandatory = $false)]
        [string]$MarketCap,        

        [parameter(Mandatory = $false)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Notes,        

        [parameter(Mandatory = $false)]
        [int]$NumEmployees,

        [parameter(Mandatory = $false)]
        [string]$PrimaryLocation,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$Phone,        

        [parameter(Mandatory = $false)]
        [bool]$Primary,

        [parameter(Mandatory = $false)]
        [string]$Profits,
        
        [parameter(Mandatory = $false)]
        [bool]$PubliclyTraded,

        [parameter(Mandatory = $false)]
        [string]$RankTier,

        [parameter(Mandatory = $false)]
        [string]$RevenuePerYear,

        [parameter(Mandatory = $false)]
        [string]$State,        

        [parameter(Mandatory = $false)]
        [string]$StockPrice,

        [parameter(Mandatory = $false)]
        [string]$StockSymbol,

        [parameter(Mandatory = $false)]
        [string]$Street,
        
        [parameter(Mandatory = $false)]
        [string]$Theme,

        [parameter(Mandatory = $false)]
        [bool]$Vendor,

        [parameter(Mandatory = $false)]
        [string]$VendorManager,

        [parameter(Mandatory = $false)]
        [string]$VendorType,        

        [parameter(Mandatory = $false)]
        [string]$Website,

        [parameter(Mandatory = $false)]
        [string]$Zip        
    )
   
    $companyBuilder = $ServiceNowClient.Companies()[$Id] 
    $parameters = $MyInvocation.BoundParameters  
    $company = New-Object -TypeName ServiceNow.Graph.Models.Company
    $company.Id = $Id

    if ($parameters.ContainsKey("AppleIcon")) {
        $company.AppleIcon = $AppleIcon
    }
    if ($parameters.ContainsKey("BannerImage")) {
        $company.BannerImage = $BannerImage
    }
    if ($parameters.ContainsKey("BannerImageLight")) {
        $company.BannerImageLight = $BannerImageLight
    }            
    if ($parameters.ContainsKey("BannerText")) {
        $company.BannerText = $BannerText
    }            
    if ($parameters.ContainsKey("City")) {
        $company.City = $City
    }            
    if ($parameters.ContainsKey("Contact")) {
        if($Contact){
            $company.Contact = Get-ReferenceLink $Contact
        } else {
            $company.Contact = Get-ReferenceLink ""
        }
    }        
    if ($parameters.ContainsKey("CoordinatesRetrievedOn")) {
        $company.CoordinatesRetrievedOn = $CoordinatesRetrievedOn
    }                 

    if ($parameters.ContainsKey("Country")) {
        $company.Country = $Country
    }                
    if ($parameters.ContainsKey("Customer")) {
        $company.Customer = $Customer
    }                
    if ($parameters.ContainsKey("FaxPhone")) {
        $company.FaxPhone = $FaxPhone
    }                
    if ($parameters.ContainsKey("Discount")) {
        $company.Discount = $Discount
    }                
    if ($parameters.ContainsKey("FaxPhone")) {
        $company.FaxPhone = $FaxPhone
    }                
    if ($parameters.ContainsKey("FiscalYear")) {
        $company.FiscalYear = $FiscalYear
    }                 
    if ($parameters.ContainsKey("Latitude")) {
        $company.Latitude = $Latitude
    }                
    if ($parameters.ContainsKey("LatLongError")) {
        $company.LatLongError = $LatLongError
    }                
    if ($parameters.ContainsKey("Longitude")) {
        $company.Longitude = $Longitude
    }    
    if ($parameters.ContainsKey("Manufacturer")) {
        $company.Manufacturer = $Manufacturer
    }    
    if ($parameters.ContainsKey("MarketCap")) {
        $company.MarketCap = $MarketCap
    }    
    if ($parameters.ContainsKey("Notes")) {
        $company.Notes = $Notes
    }    
    if ($parameters.ContainsKey("NumEmployees")) {
        $company.NumEmployees = $NumEmployees
    }    
    if ($parameters.ContainsKey("Parent")) {
        if($Parent){
            $company.Parent = Get-ReferenceLink $Parent
        } else {
            $company.Parent = Get-ReferenceLink ""
        }
    }                
    if ($parameters.ContainsKey("Phone")) {
        $company.Phone = $Phone
    }                
    if ($parameters.ContainsKey("Primary")) {
        $company.Primary = $Primary
    }                
    if ($parameters.ContainsKey("Profits")) {
        $company.Profits = $Profits
    }                
    if ($parameters.ContainsKey("PubliclyTraded")) {
        $company.PubliclyTraded = $PubliclyTraded
    }                
    if ($parameters.ContainsKey("RankTier")) {
        $company.RankTier = $RankTier
    }                
    if ($parameters.ContainsKey("RevenuePerYear")) {
        $company.RevenuePerYear = $RevenuePerYear
    }                
    if ($parameters.ContainsKey("State")) {
        $company.State = $State
    }                
    if ($parameters.ContainsKey("StockPrice")) {
        $company.StockPrice = $StockPrice
    }                
    if ($parameters.ContainsKey("StockSymbol")) {
        $company.StockSymbol = $StockSymbol
    }                
    if ($parameters.ContainsKey("Street")) {
        $company.Street = $Street
    }                
    if ($parameters.ContainsKey("Theme")) {
        if ($Theme) {
            $company.Theme = Get-ReferenceLink $Theme    
        }
        else {
            $company.Theme = Get-ReferenceLink ""
        }
    }                
    if ($parameters.ContainsKey("Vendor")) {
        $company.Vendor = $Vendor
    }                    
    if ($parameters.ContainsKey("VendorManager")) {
        $company.VendorManager = $VendorManager
    }                    
    if ($parameters.ContainsKey("VendorType")) {
        $company.VendorType = $VendorType
    }                    
    if ($parameters.ContainsKey("Website")) {
        $company.Website = $Website
    }                    
    if ($parameters.ContainsKey("Zip")) {
        $company.Zip = $Zip
    }        
    if ($parameters.ContainsKey("Name")) {
        $company.Name = $Name
    }        

    $companyBuilder.Request().UpdateAsync($company).GetAwaiter().GetResult()
}     

function Get-SnowIncident {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Incidents() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                            

function New-SnowIncident {
    param (
        [parameter(Mandatory = $true)]
        [string]$CallerId,

        [parameter(Mandatory = $true)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $true)]
        [string]$ShortDescription,

        [parameter(Mandatory = $true)]
        [string]$Category,
        
        [parameter(Mandatory = $false)]
        [string]$SysDomain,

        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,        

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Approval,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$BusinessImpact,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$Cause,

        [parameter(Mandatory = $false)]
        [string]$CausedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseCode,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [string]$DueDate,        

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,        

        [parameter(Mandatory = $false)]
        [string]$FollowUp,        

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [int]$IncidentState,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [int]$Notify,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$OriginId,
        
        [parameter(Mandatory = $false)]
        [string]$OriginTable,

        [parameter(Mandatory = $false)]
        [string]$Parent,
        
        [parameter(Mandatory = $false)]
        [string]$ParentIncident,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$ProblemId,

        [parameter(Mandatory = $false)]
        [string]$Rfc,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [int]$Severity,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [string]$SubCategory,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$WorkNotes
    )
    
    $incidentBuilder = $ServiceNowClient.Incidents()
    $incident = New-Object -TypeName ServiceNow.Graph.Models.Incident
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("SysDomain") -and $SysDomain) {
        $incident.SysDomain = Get-ReferenceLink $SysDomain
    }              
    if ($parameters.ContainsKey("Active")) {
        $incident.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
        if ($ActivityDue) {
            $incident.ActivityDue = $ActivityDue
        } 
    }                     
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $incident.AdditionalAssigneeList = $AdditionalAssigneeList
    }    
    if ($parameters.ContainsKey("Approval")) {
        $incident.Approval = $Approval
    }        
    if ($parameters.ContainsKey("AssignedTo") -and $AssignedTo) {
        $incident.AssignedTo = Get-ReferenceLink $AssignedTo
    }          
    if ($parameters.ContainsKey("AssignmentGroup")) {
        $incident.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
    }     
    if ($parameters.ContainsKey("BusinessImpact")) {
        $incident.BusinessImpact = $BusinessImpact
    }          
    if ($parameters.ContainsKey("BusinessService") -and $BusinessService) {
        $incident.BusinessService = Get-ReferenceLink $BusinessService
    }                
    if ($parameters.ContainsKey("CallerId") ) {
        $incident.CallerId = Get-ReferenceLink $CallerId
    }       
    if ($parameters.ContainsKey("Category")) {
        $incident.Category = $Category
    }         
    if ($parameters.ContainsKey("Cause")) {
        $incident.Cause = $Cause
    }          
    if ($parameters.ContainsKey("CausedBy") -and $CausedBy) {
        $incident.CausedBy = Get-ReferenceLink $CausedBy
    }          
    if ($parameters.ContainsKey("CloseCode")) {
        $incident.CloseCode = $CloseCode
    }                     
    if ($parameters.ContainsKey("CloseNotes")) {
        $incident.CloseNotes = $CloseNotes
    }    
    if ($parameters.ContainsKey("CmdbCi") -and $CmdbCi) {
        $incident.CmdbCi = Get-ReferenceLink $CmdbCi
    }          
    if ($parameters.ContainsKey("Comments")) {
        $incident.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company") -and $Company) {
        $incident.Company = Get-ReferenceLink $Company
    }              
    if ($parameters.ContainsKey("ContactType")) {
        $incident.ContactType = $ContactType
    }
    if ($parameters.ContainsKey("Contract") -and $Contract) {
        $incident.Contract = Get-ReferenceLink $Contract
    }                      
    if ($parameters.ContainsKey("Description")) {
        $incident.Description = $Description
    } 
    if ($parameters.ContainsKey("DueDate")) {
        if ($DueDate) {
            $incident.DueDate = $DueDate
        } 
    }                         
    if ($parameters.ContainsKey("ExpectedStart")) {
        if ($ExpectedStart) {
            $incident.ExpectedStart = $ExpectedStart
        }
    }                             
    if ($parameters.ContainsKey("FollowUp")) {
        if ($FollowUp) {
            $incident.FollowUp = $FollowUp
        }
    }                                 
    if ($parameters.ContainsKey("GroupList")) {
        $incident.GroupList = $GroupList
    }              
    if ($parameters.ContainsKey("Impact")) {
        $incident.Impact = $Impact
    } 
    if ($parameters.ContainsKey("IncidentState")) {
        $incident.IncidentState = $IncidentState
    }   
    if ($parameters.ContainsKey("Knowledge")) {
        $incident.Knowledge = $Knowledge
    }                  
    if ($parameters.ContainsKey("Location") -and $Location) {
        $incident.Location = Get-ReferenceLink $Location
    }     
    if ($parameters.ContainsKey("Notify")) {
        $incident.Notify = $Notify
    }              
    if ($parameters.ContainsKey("OpenedBy") -and $OpenedBy) {
        $incident.OpenedBy = Get-ReferenceLink $OpenedBy
    }     
    if ($parameters.ContainsKey("OriginId") -and $OriginId) {
        $incident.OriginId = Get-ReferenceLink $OriginId
    }  
    if ($parameters.ContainsKey("OriginTable")) {
        $incident.OriginTable = $OriginTable
    }
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $incident.Parent = Get-ReferenceLink $Parent
    }                
    if ($parameters.ContainsKey("ParentIncident") -and $ParentIncident) {
        $incident.ParentIncident = Get-ReferenceLink $ParentIncident
    }                                                                     
    if ($parameters.ContainsKey("Priority")) {
        $incident.Priority = $Priority
    }       
    if ($parameters.ContainsKey("ProblemId") -and $ProblemId) {
        $incident.ProblemId = Get-ReferenceLink $ProblemId
    }          
    if ($parameters.ContainsKey("Rfc") -and $Rfc) {
        $incident.Rfc = Get-ReferenceLink $Rfc
    }     
    if ($parameters.ContainsKey("ServiceOffering") -and $ServiceOffering) {
        $incident.ServiceOffering = Get-ReferenceLink $ServiceOffering
    } 
    if ($parameters.ContainsKey("Severity")) {
        $incident.Severity = $Severity
    }                                                   
    if ($parameters.ContainsKey("SubCategory")) {
        $incident.SubCategory = $SubCategory
    }                    
    if ($parameters.ContainsKey("ShortDescription")) {
        $incident.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("State")) {
        $incident.State = $State
    }   
    if ($parameters.ContainsKey("Urgency")) {
        $incident.Urgency = $Urgency
    }   
    if ($parameters.ContainsKey("WorkNotes")) {
        $incident.WorkNotes = $WorkNotes
    }   

    $incidentBuilder.Request().AddAsync($incident).GetAwaiter().GetResult()
}         

function Set-SnowIncident {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,        

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$BusinessImpact,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$Category,

        [parameter(Mandatory = $false)]
        [string]$Cause,

        [parameter(Mandatory = $false)]
        [string]$CausedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseCode,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [string]$DueDate,        

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,        

        [parameter(Mandatory = $false)]
        [string]$FollowUp,        

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [int]$IncidentState,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [int]$Notify,

        [parameter(Mandatory = $false)]
        [string]$OriginId,
        
        [parameter(Mandatory = $false)]
        [string]$OriginTable,

        [parameter(Mandatory = $false)]
        [string]$Parent,
        
        [parameter(Mandatory = $false)]
        [string]$ParentIncident,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$ProblemId,

        [parameter(Mandatory = $false)]
        [string]$Rfc,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [int]$Severity,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [string]$SubCategory,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$WorkNotes
    )
    
    $incidentBuilder = $ServiceNowClient.Incidents()[$Id] 
    $incident = New-Object -TypeName ServiceNow.Graph.Models.Incident
    $parameters = $MyInvocation.BoundParameters  
    $incident.Id = $Id

    if ($parameters.ContainsKey("Active")) {
        $incident.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
            $incident.ActivityDue = $ActivityDue
    }                         
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $incident.AdditionalAssigneeList = $AdditionalAssigneeList
    }    
    if ($parameters.ContainsKey("Approval")) {
        $incident.Approval = $Approval
    }        
    if ($parameters.ContainsKey("AssignedTo")) {
        if ($AssignedTo) {
            $incident.AssignedTo = Get-ReferenceLink $AssignedTo
        } else {
            $incident.AssignedTo = Get-ReferenceLink ""
        }
    }          
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if ($AssignmentGroup) {
            $incident.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        } else {
            $incident.AssignmentGroup = Get-ReferenceLink ""
        }
    }              
    if ($parameters.ContainsKey("BusinessImpact")) {
        if ($BusinessImpact) {
            $incident.BusinessImpact = Get-ReferenceLink $BusinessImpact
        } else {
            $incident.BusinessImpact = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("BusinessService")) {
        if ($BusinessService) {
            $incident.BusinessService = Get-ReferenceLink $BusinessService
        } else {
            $incident.BusinessService = Get-ReferenceLink ""
        }
    }                      
    if ($parameters.ContainsKey("Category")) {
        $incident.Category = $Category
    }         
    if ($parameters.ContainsKey("Cause")) {
        $incident.Cause = $Cause
    }          
    if ($parameters.ContainsKey("CausedBy")) {
        if($CausedBy){
            $incident.CausedBy = Get-ReferenceLink $CausedBy
        } else {
            $incident.CausedBy = Get-ReferenceLink ""
        }
    }          
    if ($parameters.ContainsKey("CloseCode")) {
        $incident.CloseCode = $CloseCode
    }                     
    if ($parameters.ContainsKey("CloseNotes")) {
        $incident.CloseNotes = $CloseNotes
    }    
    if ($parameters.ContainsKey("CmdbCi")) {
        if ($CmdbCi) {
            $incident.CmdbCi = Get-ReferenceLink $CmdbCi
        } else {
            $incident.CmdbCi = Get-ReferenceLink ""
        }
    }                          
    if ($parameters.ContainsKey("Comments")) {
        $incident.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company")) {
        if ($Company) {
            $incident.Company = Get-ReferenceLink $Company
        } else {
            $incident.Company = Get-ReferenceLink ""
        }
    }                              
    if ($parameters.ContainsKey("ContactType")) {
        $incident.ContactType = $ContactType
    }
    if ($parameters.ContainsKey("Contract")) {
        if ($Contract) {
            $incident.Contract = Get-ReferenceLink $Contract
        } else {
            $incident.Contract = Get-ReferenceLink ""
        }
    }                                  
    if ($parameters.ContainsKey("Description")) {
        $incident.Description = $Description
    } 
    if ($parameters.ContainsKey("DueDate")) {
            $incident.DueDate = $DueDate
    }                             
    if ($parameters.ContainsKey("ExpectedStart")) {
            $incident.ExpectedStart = $ExpectedStart
    }                             
    if ($parameters.ContainsKey("FollowUp")) {
            $incident.FollowUp = $FollowUp
    }                             
    if ($parameters.ContainsKey("GroupList")) {
        $incident.GroupList = $GroupList
    }              
    if ($parameters.ContainsKey("Impact")) {
        $incident.Impact = $Impact
    } 
    if ($parameters.ContainsKey("IncidentState")) {
        $incident.IncidentState = $IncidentState
    }   
    if ($parameters.ContainsKey("Knowledge")) {
        $incident.Knowledge = $Knowledge
    }             
    if ($parameters.ContainsKey("Location")) {
        if ($Location) {
            $incident.Location = Get-ReferenceLink $Location
        } else {
            $incident.Location = Get-ReferenceLink ""
        }
    }                                           
    if ($parameters.ContainsKey("Notify")) {
        $incident.Notify = $Notify
    }         
    if ($parameters.ContainsKey("OriginId")) {
        if ($OriginId) {
            $incident.OriginId = Get-ReferenceLink $OriginId
        } else {
            $incident.OriginId = Get-ReferenceLink ""
        }
    }                                                    
    if ($parameters.ContainsKey("OriginTable")) {
        $incident.OriginTable = $OriginTable
    }
    if ($parameters.ContainsKey("Parent")) {
        if ($Parent) {
            $incident.Parent = Get-ReferenceLink $Parent
        } else {
            $incident.Parent = Get-ReferenceLink ""
        }
    }                                                        
    if ($parameters.ContainsKey("ParentIncident")) {
        if ($ParentIncident) {
            $incident.ParentIncident = Get-ReferenceLink $ParentIncident
        } else {
            $incident.ParentIncident = Get-ReferenceLink ""
        }
    }                                                            
    if ($parameters.ContainsKey("Priority")) {
        $incident.Priority = $Priority
    }       
    if ($parameters.ContainsKey("ProblemId")) {
        if ($ProblemId) {
            $incident.ProblemId = Get-ReferenceLink $ProblemId
        } else {
            $incident.ProblemId = Get-ReferenceLink ""
        }
    }                                                                
    if ($parameters.ContainsKey("Rfc")) {
        if ($Rfc) {
            $incident.Rfc = Get-ReferenceLink $Rfc
        } else {
            $incident.Rfc = Get-ReferenceLink ""
        }
    }                                                                    
    if ($parameters.ContainsKey("ServiceOffering")) {
        if ($ServiceOffering) {
            $incident.ServiceOffering = Get-ReferenceLink $ServiceOffering
        } else {
            $incident.ServiceOffering = Get-ReferenceLink ""
        }
    }                                                                        
    if ($parameters.ContainsKey("Severity")) {
        $incident.Severity = $Severity
    }                                                   
    if ($parameters.ContainsKey("SubCategory")) {
        $incident.SubCategory = $SubCategory
    }                    
    if ($parameters.ContainsKey("ShortDescription")) {
        $incident.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("State")) {
        $incident.State = $State
    }   
    if ($parameters.ContainsKey("Urgency")) {
        $incident.Urgency = $Urgency
    }   
    if ($parameters.ContainsKey("WorkNotes")) {
        $incident.WorkNotes = $WorkNotes
    }   
    $incidentBuilder.Request().UpdateAsync($incident).GetAwaiter().GetResult()
}         

function Get-SnowVariable {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Variables() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                

function Get-SnowLiveProfile {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
    
        Get-Entity -CollectionBuilder $ServiceNowClient.LiveProfiles() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}    

function New-SnowLiveProfile {
    param (
        [parameter(Mandatory = $true)]
        [string]$Document,

        [parameter(Mandatory = $false)]
        [string]$Image,

        [parameter(Mandatory = $false)]
        [bool]$JoinedFeed,

        [parameter(Mandatory = $true)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$Photo,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$Status,

        [parameter(Mandatory = $false)]
        [string]$SysDomain,
        
        [parameter(Mandatory = $true)]
        [string]$Table,
        
        [parameter(Mandatory = $true)]
        [string]$Type
    )
    
    $profileRequestBuilder = $ServiceNowClient.LiveProfiles()
    $liveProfile = New-Object -TypeName ServiceNow.Graph.Models.LiveProfile
    $parameters = $MyInvocation.BoundParameters  

    $liveProfile.Document = Get-ReferenceLink $Document
    $liveProfile.Name = $Name
    $liveProfile.Table = $Table
    $liveProfile.Type = $Type

    if ($parameters.ContainsKey("Image")) {
        $liveProfile.Image = $Image
    }
    if ($parameters.ContainsKey("JoinedFeed")) {
        $liveProfile.JoinedFeed = $JoinedFeed
    }    
    if ($parameters.ContainsKey("Photo")) {
        $liveProfile.Photo = $Photo
    }
    if ($parameters.ContainsKey("ShortDescription")) {
        $liveProfile.ShortDescription = $ShortDescription
    } 
    if ($parameters.ContainsKey("Status")) {
        $liveProfile.Status = $Status
    } 
    if ($parameters.ContainsKey("SysDomain")) {
        $liveProfile.SysDomain = Get-ReferenceLink $SysDomain
    } 

    $profileRequestBuilder.Request().AddAsync($liveProfile).GetAwaiter().GetResult()
}         

function Set-SnowLiveProfile {
    param (
      [parameter(Mandatory = $true)]
      [string]$Id,

      [parameter(Mandatory = $false)]
      [string]$Image,

      [parameter(Mandatory = $false)]
      [bool]$JoinedFeed,

      [parameter(Mandatory = $false)]
      [string]$Name,

      [parameter(Mandatory = $false)]
      [string]$Photo,

      [parameter(Mandatory = $false)]
      [string]$ShortDescription,

      [parameter(Mandatory = $false)]
      [string]$Status
  )
  $profileRequestBuilder = $ServiceNowClient.LiveProfiles()[$Id]
  $liveProfile = New-Object -TypeName ServiceNow.Graph.Models.LiveProfile
  $parameters = $MyInvocation.BoundParameters
  $liveProfile.Id = $Id
  if($parameters.ContainsKey("Image"))
  {
	 $liveProfile.Image = $Image
  }
  if($parameters.ContainsKey("JoinedFeed"))
  {
	 $liveProfile.JoinedFeed = $JoinedFeed
  }
  if($parameters.ContainsKey("Name"))
  {
	 $liveProfile.Name = $Name
  }
  if($parameters.ContainsKey("Photo"))
  {
	 $liveProfile.Photo = $Photo
  }
 
  if($parameters.ContainsKey("ShortDescription"))
  {
	 $liveProfile.ShortDescription = $ShortDescription
  }
    if($parameters.ContainsKey("Status"))
  {
	 $liveProfile.Status = $Status
  }
	 

  $profileRequestBuilder.Request().UpdateAsync($liveProfile).GetAwaiter().GetResult()
  }
  function Get-SnowServiceCatalog {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
      
        Get-Entity -CollectionBuilder $ServiceNowClient.ServiceCatalogs() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}            

function Get-SnowCatalogItem {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
    Get-Entity -CollectionBuilder $ServiceNowClient.CatalogItems() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}                    
Get-SnowCat
function Get-SnowOrderGuide {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.OrderGuides() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                    

  function Get-SnowCatalogOption {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
    Get-Entity -CollectionBuilder $ServiceNowClient.CatalogOptions() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}            

function New-SnowCatalogOption {
    param (
        [parameter(Mandatory = $false)]
        [string]$CartItem,

        [parameter(Mandatory = $true)]
        [string]$ItemOptionNew,

        [parameter(Mandatory = $false)]
        [int]$Order,
        
        [parameter(Mandatory = $false)]
        [string]$ScCatItemOption,

        [parameter(Mandatory = $false)]
        [string]$Value
    )
        
    $catalogOptionsRequestBuilder = $ServiceNowClient.CatalogOptions()
    $option = New-Object -TypeName ServiceNow.Graph.Models.CatalogOption
    $parameters = $MyInvocation.BoundParameters  
            
    $option.ItemOptionNew =  Get-ReferenceLink $ItemOptionNew

    if ($parameters.ContainsKey("CartItem") -and $CartItem) {
        $option.CartItem = Get-ReferenceLink $CartItem
    }          
    if ($parameters.ContainsKey("Order")) {
        $option.Order = $Order
    }          
    if ($parameters.ContainsKey("ScCatItemOption") -and $ScCatItemOption) {
        $option.ScCatItemOption = Get-ReferenceLink $ScCatItemOption
    }          

    if ($parameters.ContainsKey("Value")) {
        $option.Value = $Value
    } 

    $catalogOptionsRequestBuilder.Request().AddAsync($option).GetAwaiter().GetResult()
}     

function Set-SnowCatalogOption {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$CartItem,

        [parameter(Mandatory = $false)]
        [string]$ScCatItemOption,

        [parameter(Mandatory = $false)]
        [string]$Value
    )
        
    $catalogOptionsRequestBuilder = $ServiceNowClient.CatalogOptions()[$Id] 
    $option = New-Object -TypeName ServiceNow.Graph.Models.CatalogOption
    $parameters = $MyInvocation.BoundParameters  
    $option.Id = $Id
            
    if ($parameters.ContainsKey("Value")) {
        $option.Value = $Value
    } 
    
    if ($parameters.ContainsKey("ScCatItemOption")) {
        if ($ScCatItemOption) {
            $option.ScCatItemOption = Get-ReferenceLink $ScCatItemOption
        } else {
            $option.ScCatItemOption = Get-ReferenceLink ""
        }
    }                                                                            

    if ($parameters.ContainsKey("CartItem")) {
        if ($CartItem) {
            $option.CartItem = Get-ReferenceLink $CartItem
        } else {
            $option.CartItem = Get-ReferenceLink ""
        }
    }                                                                            

    $catalogOptionsRequestBuilder.Request().UpdateAsync($option).GetAwaiter().GetResult()
}     

function Get-SnowVariableOwnership {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.VariableOwnerships() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                        

function New-SnowVariableOwnership {
    param (
        [parameter(Mandatory = $true)]
        [string]$RequestItem,

        [parameter(Mandatory = $true)]
        [string]$ScItemOption

    )
        
    $variableOwnershipBuilder = $ServiceNowClient.VariableOwnerships()
    $variableOwnership = New-Object -TypeName ServiceNow.Graph.Models.CatalogItemOptionMtom
            
    $variableOwnership.RequestItem =  Get-ReferenceLink $RequestItem
    $variableOwnership.ScItemOption =  Get-ReferenceLink $ScItemOption

    $variableOwnershipBuilder.Request().AddAsync($variableOwnership).GetAwaiter().GetResult()
}     

function Get-SnowCatalogRequest {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.CatalogRequests() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy     
}        

function New-SnowCatalogRequest {
    param (
        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Approval,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$CorrelationDisplay,

        [parameter(Mandatory = $false)]
        [string]$CorrelationId,

        [parameter(Mandatory = $false)]
        [string]$DeliveryAddress,        

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DueDate,

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,

        [parameter(Mandatory = $false)]
        [string]$FollowUp,

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$Order,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$ParentInteraction,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$RequestedDate,

        [parameter(Mandatory = $false)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$RequestState,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$SpecialInstructions,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [string]$SysDomain,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$UserInput,

        [parameter(Mandatory = $false)]
        [string]$WatchList,        

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$WorkNotesList        
    )
    
    $requestBuilder = $ServiceNowClient.CatalogRequests()
    $request = New-Object -TypeName ServiceNow.Graph.Models.CatalogRequest
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("Active")) {
        $request.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
        $request.ActivityDue = $ActivityDue
    }                                 
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $request.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Approval")) {
        $request.Approval = $Approval
    } 
    if ($parameters.ContainsKey("AssignedTo") -and $AssignedTo) {
        $request.AssignedTo = Get-ReferenceLink $AssignedTo
    }                  
    if ($parameters.ContainsKey("AssignmentGroup") -and $AssignmentGroup) {
        $request.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
    }     
    if ($parameters.ContainsKey("BusinessService") -and $BusinessService) {
        $request.BusinessService = Get-ReferenceLink $BusinessService
    }              
    if ($parameters.ContainsKey("ClosedBy") -and $ClosedBy) {
        $request.ClosedBy = Get-ReferenceLink $ClosedBy
    }              
    if ($parameters.ContainsKey("CloseNotes")) {
        $request.CloseNotes = $CloseNotes
    }     
    if ($parameters.ContainsKey("CmdbCi") -and $CmdbCi) {
        $request.CmdbCi = Get-ReferenceLink $CmdbCi
    }                  
    if ($parameters.ContainsKey("Comments")) {
        $request.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company") -and $Company) {
        $request.Company = Get-ReferenceLink $Company
    }    
    if ($parameters.ContainsKey("ContactType")) {
        $request.ContactType = $ContactType
    }         
    if ($parameters.ContainsKey("Contract") -and $Contract) {
        $request.Contract = Get-ReferenceLink $Contract
    }         
    if ($parameters.ContainsKey("CorrelationDisplay")) {
        $request.CorrelationDisplay = $CorrelationDisplay
    }         
    if ($parameters.ContainsKey("CorrelationId")) {
        $request.CorrelationId = $CorrelationId
    }                         
    if ($parameters.ContainsKey("DeliveryAddress")) {
        $request.DeliveryAddress = $DeliveryAddress
    }        
    if ($parameters.ContainsKey("Description")) {
        $request.Description = $Description
    }     
    if ($parameters.ContainsKey("DueDate")) {
        $request.DueDate = $DueDate
    }                                             
    if ($parameters.ContainsKey("ExpectedStart")) {
        $request.ExpectedStart = $ExpectedStart
    }                                             
    if ($parameters.ContainsKey("FollowUp")) {
        $request.FollowUp = $FollowUp
    }                                             
    if ($parameters.ContainsKey("GroupList")) {
        $request.GroupList = $GroupList
    }                                             
    if ($parameters.ContainsKey("Impact")) {
        $request.Impact = $Impact
    }    
    if ($parameters.ContainsKey("Knowledge")) {
        $request.Knowledge = $Knowledge
    }
    if ($parameters.ContainsKey("Location") -and $Location) {
        $request.Location = Get-ReferenceLink $Location
    }    
    if ($parameters.ContainsKey("OpenedBy") -and $OpenedBy) {
        $request.OpenedBy = Get-ReferenceLink $OpenedBy
    }
    if ($parameters.ContainsKey("Order")) {
        $request.Order = $Order
    }
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $request.Parent = Get-ReferenceLink $Parent
    }            
    if ($parameters.ContainsKey("ParentInteraction")) {
        $request.ParentInteraction = Get-ReferenceLink $ParentInteraction
    }
    if ($parameters.ContainsKey("Priority")) {
        $request.Priority = $Priority
    }
    if ($parameters.ContainsKey("RequestedDate")) {
        $request.RequestedDate = $RequestedDate
    }
    if ($parameters.ContainsKey("RequestedFor") -and $RequestedFor) {
        $request.RequestedFor = Get-ReferenceLink $RequestedFor
    }         
    if ($parameters.ContainsKey("RequestState")) {
        $request.RequestState = $RequestState
    }                 
    if ($parameters.ContainsKey("ServiceOffering") -and $ServiceOffering) {
        $request.ServiceOffering = Get-ReferenceLink $ServiceOffering
    }          
    if ($parameters.ContainsKey("ShortDescription")) {
        $request.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("SpecialInstructions")) {
        $request.SpecialInstructions = $SpecialInstructions
    }             
    if ($parameters.ContainsKey("State")) {
        $request.State = $State
    }   
    if ($parameters.ContainsKey("SysDomain") -and $SysDomain) {
        $request.SysDomain = Get-ReferenceLink $SysDomain
    }          
    if ($parameters.ContainsKey("Urgency")) {
        $request.Urgency = $Urgency
    }
    if ($parameters.ContainsKey("UserInput")) {
        $request.UserInput = $UserInput
    }             
    if ($parameters.ContainsKey("WatchList")) {
        $request.WatchList = $WatchList
    }             
    if ($parameters.ContainsKey("WorkNotes")) {
        $request.WorkNotes = $WorkNotes
    }             
    if ($parameters.ContainsKey("WorkNotesList")) {
        $request.WorkNotesList = $WorkNotesList
    }             

    $requestBuilder.Request().AddAsync($request).GetAwaiter().GetResult()
}         

function Set-SnowCatalogRequest {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Approval,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$CorrelationDisplay,

        [parameter(Mandatory = $false)]
        [string]$CorrelationId,

        [parameter(Mandatory = $false)]
        [string]$DeliveryAddress,        

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DueDate,

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,

        [parameter(Mandatory = $false)]
        [string]$FollowUp,

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [string]$ParentInteraction,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$RequestedDate,

        [parameter(Mandatory = $false)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$RequestState,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$SpecialInstructions,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$UserInput,

        [parameter(Mandatory = $false)]
        [string]$WatchList,        

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$WorkNotesList        
    )
    
    $requestBuilder = $ServiceNowClient.CatalogRequests()[$Id] 
    $request = New-Object -TypeName ServiceNow.Graph.Models.CatalogRequest
    $parameters = $MyInvocation.BoundParameters  
    $request.Id = $Id

    if ($parameters.ContainsKey("Active")) {
        $request.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
        $request.ActivityDue = $ActivityDue
    }                                 
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $request.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Approval")) {
        $request.Approval = $Approval
    } 
    if ($parameters.ContainsKey("AssignedTo") ) {
        if ($AssignedTo) {
            $request.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $request.AssignedTo = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if ($AssignmentGroup) {
            $request.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $request.AssignmentGroup = Get-ReferenceLink ""
        }
    }     
    if ($parameters.ContainsKey("BusinessService")) {
        if ($BusinessService) {
            $request.BusinessService = Get-ReferenceLink $BusinessService
        }
        else {
            $request.BusinessService = Get-ReferenceLink ""
        }
    }              
    if ($parameters.ContainsKey("ClosedBy")) {
        if ($ClosedBy) {
            $request.ClosedBy = Get-ReferenceLink $ClosedBy
        }
        else {
            $request.ClosedBy = Get-ReferenceLink ""
        }
    }              
    if ($parameters.ContainsKey("CloseNotes")) {
        $request.CloseNotes = $CloseNotes
    }     
    if ($parameters.ContainsKey("CmdbCi")) {
        if ($CmdbCi) {
            $request.CmdbCi = Get-ReferenceLink $CmdbCi
        }
        else {
            $request.CmdbCi = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Comments")) {
        $request.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company")) {
        if ($Company) {
            $request.Company = Get-ReferenceLink $Company
        }
        else {
            $request.Company = Get-ReferenceLink ""
        }
    }    
    if ($parameters.ContainsKey("ContactType")) {
        $request.ContactType = $ContactType
    }         
    if ($parameters.ContainsKey("Contract")) {
        if ($Contract) {
            $request.Contract = Get-ReferenceLink $Contract
        }
        else {
            $request.Contract = Get-ReferenceLink ""
        }
    }         
    if ($parameters.ContainsKey("CorrelationDisplay")) {
        $request.CorrelationDisplay = $CorrelationDisplay
    }         
    if ($parameters.ContainsKey("CorrelationId")) {
        $request.CorrelationId = $CorrelationId
    }                         
    if ($parameters.ContainsKey("DeliveryAddress")) {
        $request.DeliveryAddress = $DeliveryAddress
    }        
    if ($parameters.ContainsKey("Description")) {
        $request.Description = $Description
    }     
    if ($parameters.ContainsKey("DueDate")) {
        $request.DueDate = $DueDate
    }                                             
    if ($parameters.ContainsKey("ExpectedStart")) {
        $request.ExpectedStart = $ExpectedStart
    }                                             
    if ($parameters.ContainsKey("FollowUp")) {
        $request.FollowUp = $FollowUp
    }   
    if ($parameters.ContainsKey("GroupList")) {
        $request.GroupList = $GroupList
    }                                                                                           
    if ($parameters.ContainsKey("Impact")) {
        $request.Impact = $Impact
    }    
    if ($parameters.ContainsKey("Knowledge")) {
        $request.Knowledge = $Knowledge
    }
    if ($parameters.ContainsKey("Location")) {
        if ($Location) {
            $request.Location = Get-ReferenceLink $Location
        }
        else {
            $request.Location = Get-ReferenceLink ""
        }
    }    
    if ($parameters.ContainsKey("OpenedBy")) {
        if ($OpenedBy) {
            $request.OpenedBy = Get-ReferenceLink $OpenedBy
        }
        else {
            $request.OpenedBy = Get-ReferenceLink ""
        }
    }

    if ($parameters.ContainsKey("Parent")) {
        if ($Parent) {
            $request.Parent = Get-ReferenceLink $Parent
        }
        else {
            $request.Parent = Get-ReferenceLink ""
        }
    }            
    if ($parameters.ContainsKey("ParentInteraction")) {
        if ($ParentInteraction) {
            $request.ParentInteraction = Get-ReferenceLink $ParentInteraction
        }
        else {
            $request.ParentInteraction = Get-ReferenceLink ""
        }
    }
    if ($parameters.ContainsKey("Priority")) {
        $request.Priority = $Priority
    }
    if ($parameters.ContainsKey("RequestedDate")) {
        $request.RequestedDate = $RequestedDate
    }
    if ($parameters.ContainsKey("RequestedFor")) {
        if ($RequestedFor) {
            $request.RequestedFor = Get-ReferenceLink $RequestedFor
        }
        else {
            $request.RequestedFor = Get-ReferenceLink ""
        }
    }         
    if ($parameters.ContainsKey("RequestState")) {
        $request.RequestState = $RequestState
    }                 
    if ($parameters.ContainsKey("ServiceOffering")) {
        if ($ServiceOffering) {
            $request.ServiceOffering = Get-ReferenceLink $ServiceOffering
        }
        else {
            $request.ServiceOffering = Get-ReferenceLink ""
        }
    }          
    if ($parameters.ContainsKey("ShortDescription")) {
        $request.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("SpecialInstructions")) {
        $request.SpecialInstructions = $SpecialInstructions
    }             
    if ($parameters.ContainsKey("State")) {
        $request.State = $State
    }   
    if ($parameters.ContainsKey("Urgency")) {
        $request.Urgency = $Urgency
    }
    if ($parameters.ContainsKey("UserInput")) {
        $request.UserInput = $UserInput
    }             
    if ($parameters.ContainsKey("WatchList")) {
        $request.WatchList = $WatchList
    }             
    if ($parameters.ContainsKey("WorkNotes")) {
        $request.WorkNotes = $WorkNotes
    }             
    if ($parameters.ContainsKey("WorkNotesList")) {
        $request.WorkNotesList = $WorkNotesList
    }             

    $requestBuilder.Request().UpdateAsync($request).GetAwaiter().GetResult()
}         

function Get-SnowRequestItems {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.RequestItems() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}        

function New-SnowRequestItem {
    param (
        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Approval,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$CatItem,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ConfigurationItem,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$CorrelationDisplay,

        [parameter(Mandatory = $false)]
        [string]$CorrelationId,

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DueDate,

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,

        [parameter(Mandatory = $false)]
        [string]$FollowUp,

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$Order,

        [parameter(Mandatory = $false)]
        [string]$OrderGuide,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$Request,

        [parameter(Mandatory = $false)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$ScCatalog,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,
        
        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [string]$SysDomain,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$UserInput,

        [parameter(Mandatory = $false)]
        [string]$WatchList,        

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$WorkNotesList        
    )
    
    $requestItemBuilder = $ServiceNowClient.RequestItems()
    $requestItem = New-Object -TypeName ServiceNow.Graph.Models.RequestItem
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("Active")) {
        $requestItem.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
        $requestItem.ActivityDue = $ActivityDue
    }                                 
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $requestItem.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Approval")) {
        $requestItem.Approval = $Approval
    } 
    if ($parameters.ContainsKey("AssignedTo") -and $AssignedTo) {
        $requestItem.AssignedTo = Get-ReferenceLink $AssignedTo
    }                  
    if ($parameters.ContainsKey("AssignmentGroup") -and $AssignmentGroup) {
        $requestItem.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
    }     
    if ($parameters.ContainsKey("BusinessService") -and $BusinessService) {
        $requestItem.BusinessService = Get-ReferenceLink $BusinessService
    }              
    if ($parameters.ContainsKey("CatItem") -and $CatItem) {
        $requestItem.CatItem = Get-ReferenceLink $CatItem
    }              
    if ($parameters.ContainsKey("ClosedBy") -and $ClosedBy) {
        $requestItem.ClosedBy = Get-ReferenceLink $ClosedBy
    }              
    if ($parameters.ContainsKey("CloseNotes")) {
        $requestItem.CloseNotes = $CloseNotes
    }     
    if ($parameters.ContainsKey("CmdbCi") -and $CmdbCi) {
        $requestItem.CmdbCi = Get-ReferenceLink $CmdbCi
    }                  
    if ($parameters.ContainsKey("Comments")) {
        $requestItem.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company") -and $Company) {
        $requestItem.Company = Get-ReferenceLink $Company
    }    
    if ($parameters.ContainsKey("ConfigurationItem") -and $ConfigurationItem) {
        $requestItem.ConfigurationItem = Get-ReferenceLink $ConfigurationItem
    }    
    if ($parameters.ContainsKey("ContactType")) {
        $requestItem.ContactType = $ContactType
    }         
    if ($parameters.ContainsKey("Contract") -and $Contract) {
        $requestItem.Contract = Get-ReferenceLink $Contract
    }         
    if ($parameters.ContainsKey("CorrelationDisplay")) {
        $requestItem.CorrelationDisplay = $CorrelationDisplay
    }         
    if ($parameters.ContainsKey("CorrelationId")) {
        $requestItem.CorrelationId = $CorrelationId
    }                         
    if ($parameters.ContainsKey("Description")) {
        $requestItem.Description = $Description
    }     
    if ($parameters.ContainsKey("DueDate")) {
        $requestItem.DueDate = $DueDate
    }                                             
    if ($parameters.ContainsKey("ExpectedStart")) {
        $requestItem.ExpectedStart = $ExpectedStart
    }                                             
    if ($parameters.ContainsKey("FollowUp")) {
        $requestItem.FollowUp = $FollowUp
    }                                             
    if ($parameters.ContainsKey("GroupList")) {
        $requestItem.GroupList = $GroupList
    }                                             
    if ($parameters.ContainsKey("Impact")) {
        $requestItem.Impact = $Impact
    }    
    if ($parameters.ContainsKey("Knowledge")) {
        $requestItem.Knowledge = $Knowledge
    }
    if ($parameters.ContainsKey("Location") -and $Location) {
        $requestItem.Location = Get-ReferenceLink $Location
    }    
    if ($parameters.ContainsKey("OpenedBy") -and $OpenedBy) {
        $requestItem.OpenedBy = Get-ReferenceLink $OpenedBy
    }
    if ($parameters.ContainsKey("Order")) {
        $requestItem.Order = $Order
    }
    if ($parameters.ContainsKey("OrderGuide") -and $OrderGuide) {
        $requestItem.OrderGuide = Get-ReferenceLink $OrderGuide
    }            
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $requestItem.Parent = Get-ReferenceLink $Parent
    }            
    if ($parameters.ContainsKey("Priority")) {
        $requestItem.Priority = $Priority
    }
    if ($parameters.ContainsKey("RequestedFor") -and $RequestedFor) {
        $requestItem.RequestedFor = Get-ReferenceLink $RequestedFor
    }         
    if ($parameters.ContainsKey("ScCatalog") -and $ScCatalog) {
        $requestItem.ScCatalog = Get-ReferenceLink $ScCatalog
    }          
    if ($parameters.ContainsKey("ServiceOffering") -and $ServiceOffering) {
        $requestItem.ServiceOffering = Get-ReferenceLink $ServiceOffering
    }          
    if ($parameters.ContainsKey("ShortDescription")) {
        $requestItem.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("State")) {
        $requestItem.State = $State
    }   
    if ($parameters.ContainsKey("SysDomain") -and $SysDomain) {
        $requestItem.SysDomain = Get-ReferenceLink $SysDomain
    }          
    if ($parameters.ContainsKey("Urgency")) {
        $requestItem.Urgency = $Urgency
    }
    if ($parameters.ContainsKey("UserInput")) {
        $requestItem.UserInput = $UserInput
    }             
    if ($parameters.ContainsKey("WatchList")) {
        $requestItem.WatchList = $WatchList
    }             
    if ($parameters.ContainsKey("WorkNotes")) {
        $requestItem.WorkNotes = $WorkNotes
    }             
    if ($parameters.ContainsKey("WorkNotesList")) {
        $requestItem.WorkNotesList = $WorkNotesList
    }             

    $requestItemBuilder.Request().AddAsync($requestItem).GetAwaiter().GetResult()
}         

function Set-SnowRequestItem {
    param (
        [Parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Approval,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ConfigurationItem,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$CorrelationDisplay,

        [parameter(Mandatory = $false)]
        [string]$CorrelationId,

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DueDate,

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,

        [parameter(Mandatory = $false)]
        [string]$FollowUp,

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$OrderGuide,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,
        
        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$UserInput,

        [parameter(Mandatory = $false)]
        [string]$WatchList,        

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$WorkNotesList        
    )

    
    $requestItemsBuilder = $ServiceNowClient.RequestItems()[$Id] 
    $requestItem = New-Object -TypeName ServiceNow.Graph.Models.RequestItem
    $parameters = $MyInvocation.BoundParameters  
    $requestItem.Id = $Id


    if ($parameters.ContainsKey("Active")) {
        $requestItem.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
        $requestItem.ActivityDue = $ActivityDue
    }                                 
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $requestItem.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Approval")) {
        $requestItem.Approval = $Approval
    } 
    if ($parameters.ContainsKey("AssignedTo")) {
        if ($AssignedTo) {
            $requestItem.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $requestItem.AssignedTo = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if ($AssignmentGroup) {
            $requestItem.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $requestItem.AssignmentGroup = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("BusinessService")) {
        if ($BusinessService) {
            $requestItem.BusinessService = Get-ReferenceLink $BusinessService
        }
        else {
            $requestItem.BusinessService = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ClosedBy")) {
        if ($ClosedBy) {
            $requestItem.ClosedBy = Get-ReferenceLink $ClosedBy
        }
        else {
            $requestItem.ClosedBy = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("CloseNotes")) {
        $requestItem.CloseNotes = $CloseNotes
    }     
    if ($parameters.ContainsKey("CmdbCi")) {
        if ($CmdbCi) {
            $requestItem.CmdbCi = Get-ReferenceLink $CmdbCi
        }
        else {
            $requestItem.CmdbCi = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Comments")) {
        $requestItem.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company")) {
        if ($Company) {
            $requestItem.Company = Get-ReferenceLink $Company
        }
        else {
            $requestItem.Company = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ConfigurationItem")) {
        if ($ConfigurationItem) {
            $requestItem.ConfigurationItem = Get-ReferenceLink $ConfigurationItem
        }
        else {
            $requestItem.ConfigurationItem = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ContactType")) {
        $requestItem.ContactType = $ContactType
    }         
    if ($parameters.ContainsKey("Contract")) {
        if ($Contract) {
            $requestItem.Contract = Get-ReferenceLink $Contract
        }
        else {
            $requestItem.Contract = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("CorrelationDisplay")) {
        $requestItem.CorrelationDisplay = $CorrelationDisplay
    }         
    if ($parameters.ContainsKey("CorrelationId")) {
        $requestItem.CorrelationId = $CorrelationId
    }                         
    if ($parameters.ContainsKey("Description")) {
        $requestItem.Description = $Description
    }     
    if ($parameters.ContainsKey("DueDate")) {
        $requestItem.DueDate = $DueDate
    }                                             
    if ($parameters.ContainsKey("ExpectedStart")) {
        $requestItem.ExpectedStart = $ExpectedStart
    }                                             
    if ($parameters.ContainsKey("FollowUp")) {
        $requestItem.FollowUp = $FollowUp
    }                                             
    if ($parameters.ContainsKey("GroupList")) {
        $requestItem.GroupList = $GroupList
    }                                             
    if ($parameters.ContainsKey("Impact")) {
        $requestItem.Impact = $Impact
    }    
    if ($parameters.ContainsKey("Knowledge")) {
        $requestItem.Knowledge = $Knowledge
    }
    if ($parameters.ContainsKey("Location")) {
        if ($Location) {
            $requestItem.Location = Get-ReferenceLink $Location
        }
        else {
            $requestItem.Location = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("OpenedBy")) {
        if ($OpenedBy) {
            $requestItem.OpenedBy = Get-ReferenceLink $OpenedBy
        }
        else {
            $requestItem.OpenedBy = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("OrderGuide")) {
        if ($OrderGuide) {
            $requestItem.OrderGuide = Get-ReferenceLink $OrderGuide
        }
        else {
            $requestItem.OrderGuide = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Parent")) {
        if ($Parent) {
            $requestItem.Parent = Get-ReferenceLink $Parent
        }
        else {
            $requestItem.Parent = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Priority")) {
        $requestItem.Priority = $Priority
    }
    if ($parameters.ContainsKey("RequestedFor")) {
        if ($RequestedFor) {
            $requestItem.RequestedFor = Get-ReferenceLink $RequestedFor
        }
        else {
            $requestItem.RequestedFor = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ServiceOffering")) {
        if ($ServiceOffering) {
            $requestItem.ServiceOffering = Get-ReferenceLink $ServiceOffering
        }
        else {
            $requestItem.ServiceOffering = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ShortDescription")) {
        $requestItem.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("State")) {
        $requestItem.State = $State
    }   
    if ($parameters.ContainsKey("Urgency")) {
        $requestItem.Urgency = $Urgency
    }
    if ($parameters.ContainsKey("UserInput")) {
        $requestItem.UserInput = $UserInput
    }             
    if ($parameters.ContainsKey("WatchList")) {
        $requestItem.WatchList = $WatchList
    }             
    if ($parameters.ContainsKey("WorkNotes")) {
        $requestItem.WorkNotes = $WorkNotes
    }             
    if ($parameters.ContainsKey("WorkNotesList")) {
        $requestItem.WorkNotesList = $WorkNotesList
    }             
        
    $requestItemsBuilder.Request().UpdateAsync($requestItem).GetAwaiter().GetResult()
}         

function Get-SnowCatalogTask {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.CatalogTasks() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy     
}        

function New-SnowCatalogTask {
    param (
        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Approval,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$CorrelationDisplay,

        [parameter(Mandatory = $false)]
        [string]$CorrelationId,

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DueDate,

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,

        [parameter(Mandatory = $false)]
        [string]$FollowUp,

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$Order,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $true)]
        [string]$Request,

        [parameter(Mandatory = $false)]
        [string]$RequestItem,

        [parameter(Mandatory = $false)]
        [string]$ScCatalog,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,
        
        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [string]$SysDomain,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$UserInput,

        [parameter(Mandatory = $false)]
        [string]$WatchList,        

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$WorkNotesList        
    )
    
    $catalogTaskBuilder = $ServiceNowClient.RequestItems()
    $task = New-Object -TypeName ServiceNow.Graph.Models.CatalogTask
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("Active")) {
        $task.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
        $task.ActivityDue = $ActivityDue
    }                                 
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $task.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Approval")) {
        $task.Approval = $Approval
    } 
    if ($parameters.ContainsKey("AssignedTo") -and $AssignedTo) {
        $task.AssignedTo = Get-ReferenceLink $AssignedTo
    }                  
    if ($parameters.ContainsKey("AssignmentGroup") -and $AssignmentGroup) {
        $task.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
    }     
    if ($parameters.ContainsKey("BusinessService") -and $BusinessService) {
        $task.BusinessService = Get-ReferenceLink $BusinessService
    }              
    if ($parameters.ContainsKey("ClosedBy") -and $ClosedBy) {
        $task.ClosedBy = Get-ReferenceLink $ClosedBy
    }              
    if ($parameters.ContainsKey("CloseNotes")) {
        $task.CloseNotes = $CloseNotes
    }     
    if ($parameters.ContainsKey("CmdbCi") -and $CmdbCi) {
        $task.CmdbCi = Get-ReferenceLink $CmdbCi
    }                  
    if ($parameters.ContainsKey("Comments")) {
        $task.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company") -and $Company) {
        $task.Company = Get-ReferenceLink $Company
    }    
    if ($parameters.ContainsKey("ContactType")) {
        $task.ContactType = $ContactType
    }         
    if ($parameters.ContainsKey("Contract") -and $Contract) {
        $task.Contract = Get-ReferenceLink $Contract
    }         
    if ($parameters.ContainsKey("CorrelationDisplay")) {
        $task.CorrelationDisplay = $CorrelationDisplay
    }         
    if ($parameters.ContainsKey("CorrelationId")) {
        $task.CorrelationId = $CorrelationId
    }                         
    if ($parameters.ContainsKey("Description")) {
        $task.Description = $Description
    }     
    if ($parameters.ContainsKey("DueDate")) {
        $task.DueDate = $DueDate
    }                                             
    if ($parameters.ContainsKey("ExpectedStart")) {
        $task.ExpectedStart = $ExpectedStart
    }                                             
    if ($parameters.ContainsKey("FollowUp")) {
        $task.FollowUp = $FollowUp
    }                                             
    if ($parameters.ContainsKey("GroupList")) {
        $task.GroupList = $GroupList
    }                                             
    if ($parameters.ContainsKey("Impact")) {
        $task.Impact = $Impact
    }    
    if ($parameters.ContainsKey("Knowledge")) {
        $task.Knowledge = $Knowledge
    }
    if ($parameters.ContainsKey("Location") -and $Location) {
        $task.Location = Get-ReferenceLink $Location
    }    
    if ($parameters.ContainsKey("OpenedBy") -and $OpenedBy) {
        $task.OpenedBy = Get-ReferenceLink $OpenedBy
    }
    if ($parameters.ContainsKey("Order")) {
        $task.Order = $Order
    }
    if ($parameters.ContainsKey("Parent") -and $Parent) {
        $task.Parent = Get-ReferenceLink $Parent
    }            
    if ($parameters.ContainsKey("Priority")) {
        $task.Priority = $Priority
    }
    if ($parameters.ContainsKey("Request") -and $Request) {
        $task.Request = Get-ReferenceLink $Request
    }          
    if ($parameters.ContainsKey("RequestItem") -and $RequestItem) {
        $task.RequestItem = Get-ReferenceLink $RequestItem
    }          
    if ($parameters.ContainsKey("ScCatalog") -and $ScCatalog) {
        $task.ScCatalog = Get-ReferenceLink $ScCatalog
    }          
    if ($parameters.ContainsKey("ServiceOffering") -and $ServiceOffering) {
        $task.ServiceOffering = Get-ReferenceLink $ServiceOffering
    }          
    if ($parameters.ContainsKey("ShortDescription")) {
        $task.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("State")) {
        $task.State = $State
    }   
    if ($parameters.ContainsKey("SysDomain") -and $SysDomain) {
        $task.SysDomain = Get-ReferenceLink $SysDomain
    }          
    if ($parameters.ContainsKey("Urgency")) {
        $task.Urgency = $Urgency
    }
    if ($parameters.ContainsKey("UserInput")) {
        $task.UserInput = $UserInput
    }             
    if ($parameters.ContainsKey("WatchList")) {
        $task.WatchList = $WatchList
    }             
    if ($parameters.ContainsKey("WorkNotes")) {
        $task.WorkNotes = $WorkNotes
    }             
    if ($parameters.ContainsKey("WorkNotesList")) {
        $task.WorkNotesList = $WorkNotesList
    }             

    $catalogTaskBuilder.Request().AddAsync($task).GetAwaiter().GetResult()
}         

function Set-SnowCatalogTask {
    param (
        [Parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$ActivityDue,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Approval,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Contract,

        [parameter(Mandatory = $false)]
        [string]$CorrelationDisplay,

        [parameter(Mandatory = $false)]
        [string]$CorrelationId,

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DueDate,

        [parameter(Mandatory = $false)]
        [string]$ExpectedStart,

        [parameter(Mandatory = $false)]
        [string]$FollowUp,

        [parameter(Mandatory = $false)]
        [string]$GroupList,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$Parent,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $true)]
        [string]$Request,

        [parameter(Mandatory = $false)]
        [string]$RequestItem,

        [parameter(Mandatory = $false)]
        [string]$ScCatalog,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,
        
        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$UserInput,

        [parameter(Mandatory = $false)]
        [string]$WatchList,        

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$WorkNotesList        
    )
    $catalogTaskBuilder = $ServiceNowClient.RequestItems()[$Id] 
    $task = New-Object -TypeName ServiceNow.Graph.Models.CatalogTask
    $parameters = $MyInvocation.BoundParameters  
    $task.Id = $Id


    if ($parameters.ContainsKey("Active")) {
        $task.Active = $Active
    }
    if ($parameters.ContainsKey("ActivityDue")) {
        $task.ActivityDue = $ActivityDue
    }                                 
    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $task.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Approval")) {
        $task.Approval = $Approval
    } 
    if ($parameters.ContainsKey("AssignedTo")) {
        if ($AssignedTo) {
            $task.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $task.AssignedTo = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if ($AssignmentGroup) {
            $task.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $task.AssignmentGroup = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("BusinessService")) {
        if ($BusinessService) {
            $task.BusinessService = Get-ReferenceLink $BusinessService
        }
        else {
            $task.BusinessService = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ClosedBy")) {
        if ($ClosedBy) {
            $task.ClosedBy = Get-ReferenceLink $ClosedBy
        }
        else {
            $task.ClosedBy = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("CloseNotes")) {
        $task.CloseNotes = $CloseNotes
    }     
    if ($parameters.ContainsKey("CmdbCi")) {
        if ($CmdbCi) {
            $task.CmdbCi = Get-ReferenceLink $CmdbCi
        }
        else {
            $task.CmdbCi = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Comments")) {
        $task.Comments = $Comments
    }
    if ($parameters.ContainsKey("Company")) {
        if ($Company) {
            $task.Company = Get-ReferenceLink $Company
        }
        else {
            $task.Company = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ContactType")) {
        $task.ContactType = $ContactType
    }         
    if ($parameters.ContainsKey("Contract")) {
        if ($Contract) {
            $task.Contract = Get-ReferenceLink $Contract
        }
        else {
            $task.Contract = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("CorrelationDisplay")) {
        $task.CorrelationDisplay = $CorrelationDisplay
    }         
    if ($parameters.ContainsKey("CorrelationId")) {
        $task.CorrelationId = $CorrelationId
    }                         
    if ($parameters.ContainsKey("Description")) {
        $task.Description = $Description
    }     
    if ($parameters.ContainsKey("DueDate")) {
        $task.DueDate = $DueDate
    }                                             
    if ($parameters.ContainsKey("ExpectedStart")) {
        $task.ExpectedStart = $ExpectedStart
    }                                             
    if ($parameters.ContainsKey("FollowUp")) {
        $task.FollowUp = $FollowUp
    }                                             
    if ($parameters.ContainsKey("GroupList")) {
        $task.GroupList = $GroupList
    }                                             
    if ($parameters.ContainsKey("Impact")) {
        $task.Impact = $Impact
    }    
    if ($parameters.ContainsKey("Knowledge")) {
        $task.Knowledge = $Knowledge
    }
    if ($parameters.ContainsKey("Location")) {
        if ($Location) {
            $task.Location = Get-ReferenceLink $Location
        }
        else {
            $task.Location = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("OpenedBy")) {
        if ($OpenedBy) {
            $task.OpenedBy = Get-ReferenceLink $OpenedBy
        }
        else {
            $task.OpenedBy = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Parent")) {
        if ($Parent) {
            $task.Parent = Get-ReferenceLink $Parent
        }
        else {
            $task.Parent = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("Priority")) {
        $task.Priority = $Priority
    }
    if ($parameters.ContainsKey("Request")) {
        if ($Request) {
            $task.Request = Get-ReferenceLink $Request
        }
        else {
            $task.Request = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("RequestItem")) {
        if ($RequestItem) {
            $task.RequestItem = Get-ReferenceLink $RequestItem
        }
        else {
            $task.RequestItem = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ScCatalog")) {
        if ($ScCatalog) {
            $task.ScCatalog = Get-ReferenceLink $ScCatalog
        }
        else {
            $task.ScCatalog = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ServiceOffering")) {
        if ($ServiceOffering) {
            $task.ServiceOffering = Get-ReferenceLink $ServiceOffering
        }
        else {
            $task.ServiceOffering = Get-ReferenceLink ""
        }
    }                  
    if ($parameters.ContainsKey("ShortDescription")) {
        $task.ShortDescription = $ShortDescription
    }
    if ($parameters.ContainsKey("State")) {
        $task.State = $State
    }   
    if ($parameters.ContainsKey("Urgency")) {
        $task.Urgency = $Urgency
    }
    if ($parameters.ContainsKey("UserInput")) {
        $task.UserInput = $UserInput
    }             
    if ($parameters.ContainsKey("WatchList")) {
        $task.WatchList = $WatchList
    }             
    if ($parameters.ContainsKey("WorkNotes")) {
        $task.WorkNotes = $WorkNotes
    }             
    if ($parameters.ContainsKey("WorkNotesList")) {
        $task.WorkNotesList = $WorkNotesList
    }             
        
    $catalogTaskBuilder.Request().UpdateAsync($task).GetAwaiter().GetResult()
}         

function Get-SnowAttachment {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter=""        

    )
    $collectionBuilder = $ServiceNowClient.Attachments()        
    $outcome = $null
    if ($Id) {
        $outcome = $collectionBuilder[$Id].Request().GetAsync().GetAwaiter().GetResult()    
    }
    else {
        $page = $collectionBuilder.Request().Filter($Filter).Top($Global:PageSize).GetAsync().GetAwaiter().GetResult()
        if ($page -and $page.CurrentPage) {
            $outcome = [System.Collections.Generic.List[ServiceNow.Graph.Models.Attachment]]$page.CurrentPage
            $nextPageRequest = $page.NextPageRequest
            while ($null -ne $nextPageRequest) {
                $nextPage = $nextPageRequest.GetAsync().GetAwaiter().GetResult()
                if ($null -ne $nextPage -and $nextPage.CurrentPage.Count -ne 0) {
                    $outcome.AddRange($nextPage.CurrentPage)
                }
                $nextPageRequest = $nextPage.NextPageRequest
            }
        }
    }
      $outcome
}    

function New-SnowAttachment {
    param (
        [parameter(Mandatory = $true)]
        [string]$FileName,

        [parameter(Mandatory = $true)]
        [string]$TableName,

        [parameter(Mandatory = $true)]
        [string]$TableSysId,
            
        [parameter(Mandatory = $true)]
        [string]$ContentType,

        [parameter(Mandatory = $true)]
        [string]$Image
    )
    
    $attachmentRequestBuilder = $ServiceNowClient.Attachments()
    $attachment = New-Object -TypeName ServiceNow.Graph.Models.Attachment

    $attachment.FileName = $FileName
    $attachment.TableName = $TableName
    $attachment.TableSysId = $TableSysId
    $attachment.ContentType = $ContentType
    $attachment.Image = $Image

    $attachmentRequestBuilder.Request().AddAsync($attachment).GetAwaiter().GetResult()
}
function Remove-SnowAttachment {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.Attachments()[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
}

function Get-SnowRoleHasGroup {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )

    Get-Entity -CollectionBuilder $ServiceNowClient.GroupHasRoles() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}        

function New-SnowRoleHasGroup {
    param (
        [parameter(Mandatory = $true)]
        [string]$Role,

        [parameter(Mandatory = $true)]
        [string]$Group       
    )
    $membership = New-Object -TypeName ServiceNow.Graph.Models.GroupHasRole

    $membership.Group = Get-ReferenceLink $Group
    $membership.Role = Get-ReferenceLink $Role

    $ServiceNowClient.GroupHasRoles().Request().AddAsync($membership).GetAwaiter().GetResult()
}         

function Remove-SnowRoleHasGroup {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.GroupHasRoles()[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
}         
function Get-SnowRoleHasUser {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.UserHasRoles() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}        

function New-SnowRoleHasUser {
    param (
        [parameter(Mandatory = $true)]
        [string]$Role,

        [parameter(Mandatory = $true)]
        [string]$User,

        [parameter(Mandatory = $false)]
        [string]$State        
    )
    $parameters = $MyInvocation.BoundParameters  
    $membership = New-Object -TypeName ServiceNow.Graph.Models.UserHasRole

    $membership.User = Get-ReferenceLink $User
    $membership.Role = Get-ReferenceLink $Role

    if ($parameters.ContainsKey("State")) {
        $membership.State = $State
    }
    $ServiceNowClient.UserHasRoles().Request().AddAsync($membership).GetAwaiter().GetResult()
}         

function Remove-SnowRoleHasUser {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.UserHasRoles()[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
}         

function Get-SnowRole {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
  
        Get-Entity -CollectionBuilder $ServiceNowClient.Roles() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}

function Get-SnowRoleHasRole {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.RoleHasRoles() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}        

function Get-SnowTask {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
    Get-Entity -CollectionBuilder $ServiceNowClient.Tasks() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}        

function Get-SnowJournalFields {
    param (
        [parameter(Mandatory = $true)]
        [String]$Id,

        [parameter(Mandatory = $true)]
        [String]$Select,

        [parameter(Mandatory = $true)]
        [String]$Table
    )
        $params = @{sysparm_display_value = 'true'}
        switch ($Table.ToLower()) {
            "sc_request" { $builder = $ServiceNowClient.CatalogRequests() }
            "sc_req_item" {$builder = $ServiceNowClient.RequestItems()}
            "sc_task" {$builder = $ServiceNowClient.CatalogTasks()}
            "incident" {$builder = $ServiceNowClient.Incidents()}
        }
        Get-Entity -CollectionBuilder $builder -Id $Id  -Select $Select  -QueryParams $params
}        

function Set-SnowUserPassword {
    param (
        [parameter(Mandatory = $true)]
        [String]$Id,

        [parameter(Mandatory = $true)]
        [securestring]$Password
    )
        $QueryParams = @{sysparm_input_display_value = 'true'}
        $params = New-Object -TypeName System.Collections.Generic.List[ServiceNow.Graph.Requests.Options.QueryOption]
        foreach ($queryParam in $QueryParams.GetEnumerator()) {
            $queryOption = New-Object -TypeName ServiceNow.Graph.Requests.Options.QueryOption -ArgumentList $queryParam.Key, $queryParam.Value
            $params.Add($queryOption) | Out-Null
        }
        $userRequestBuilder = $ServiceNowClient.Users()[$Id] 
        $userUpdate = New-Object -TypeName ServiceNow.Graph.Models.User
        $userUpdate.Id = $Id
        $plainPW = ""
        $ptr = [System.IntPtr]::Zero
        try {
            $ptr = [System.IntPtr]::Zero    
            $ptr = [System.Runtime.InteropServices.Marshal]::SecureStringToGlobalAllocUnicode($Password)
            $plainPW = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($ptr)
        }
        finally {
            [System.Runtime.InteropServices.Marshal]::ZeroFreeGlobalAllocUnicode($ptr)
        }        
        $userUpdate.UserPassword = $plainPW
        
        $userRequestBuilder.Request($params).UpdateAsync($userUpdate).GetAwaiter().GetResult()
}        
function Get-Entity {
    param (
        [parameter(Mandatory = $true)]
        $CollectionBuilder,

        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy,

        [parameter(Mandatory = $false)]
        [hashtable]$QueryParams=@{}                
    )
    $params = New-Object -TypeName System.Collections.Generic.List[ServiceNow.Graph.Requests.Options.QueryOption]
    foreach ($queryParam in $QueryParams.GetEnumerator()) {
        $queryOption = New-Object -TypeName ServiceNow.Graph.Requests.Options.QueryOption -ArgumentList $queryParam.Key, $queryParam.Value
        $params.Add($queryOption) | Out-Null
    }


    $outcome = $null
    if ($Id) {
        $outcome = $CollectionBuilder[$Id].Request($params).Select($Select).GetAsync().GetAwaiter().GetResult()   
    }
    else {
        $request = $CollectionBuilder.Request()
        if ($filter) {
            $request = $request.Filter($Filter)
        }
        if ($Select) {
            $request = $request.Select($Select)                
        }
        if ($OrderBy) {
            $request = $request.OrderBy($OrderBy)
        }
        $page = $request.Top($Global:PageSize).GetAsync().GetAwaiter().GetResult()
        if ($page -and $page.CurrentPage) {
            $outcome = $page.CurrentPage
            $nextPageRequest = $page.NextPageRequest
            while ($null -ne $nextPageRequest) {
                $nextPage = $nextPageRequest.GetAsync().GetAwaiter().GetResult()
                if ($null -ne $nextPage -and $nextPage.CurrentPage.Count -ne 0) {
                    $outcome.AddRange($nextPage.CurrentPage)
                }
                $nextPageRequest = $nextPage.NextPageRequest
            }
        }
    }
 
    $outcome    
}

function Get-ReferenceLink {
    param (
        [Parameter(Position = 0)]
        [string]$Value,

        [parameter(Mandatory = $false, Position = 1)]
        [string]$Link
    )
    $refLink = New-Object -TypeName ServiceNow.Graph.Models.ReferenceLink
    $refLink.Value = $Value
        
    if (-not [string]::IsNullOrEmpty($Link)) {
        $refLink.Link = $Link
    }
    $refLink
}

function Get-SnowUser {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Users() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}

function New-SnowUser {
    param (
        [parameter(Mandatory = $false)]
        [string]$ApprovalThreshold,

        [parameter(Mandatory = $false)]
        [bool]$Active,            

        [parameter(Mandatory = $false)]
        [string]$HomePhone,

        [parameter(Mandatory = $false)]
        [int]$CalendarIntegration,
            
        [parameter(Mandatory = $false)]
        [string]$Country,
            
        [parameter(Mandatory = $false)]
        [string]$Division,

        [parameter(Mandatory = $false)]
        [string]$UserSecret,

        [parameter(Mandatory = $false)]
        [string]$Source,

        [parameter(Mandatory = $false)]
        [string]$State,

        [parameter(Mandatory = $false)]
        [string]$FirstName,

        [parameter(Mandatory = $false)]
        [string]$MiddleName,

        [parameter(Mandatory = $false)]
        [string]$LastName,

        [parameter(Mandatory = $false)]
        [string]$EmployeeNumber,

        [parameter(Mandatory = $false)]
        [string]$Gender,
            
        [parameter(Mandatory = $false)]
        [string]$UserName,
            
        [parameter(Mandatory = $false)]
        [string]$DateFormat,
            
        [parameter(Mandatory = $false)]
        [string]$TimeZone,

        [parameter(Mandatory = $false)]
        [string]$City,

        [parameter(Mandatory = $false)]
        [string]$Title,

        [parameter(Mandatory = $false)]
        [bool]$InternalIntegrationUser,

        [parameter(Mandatory = $false)]
        [string]$Street,

        [parameter(Mandatory = $false)]
        [string]$Email,

        [parameter(Mandatory = $false)]
        [string]$Introduction,

        [parameter(Mandatory = $false)]
        [string]$PreferredLanguage,

        [parameter(Mandatory = $false)]
        [string]$Phone,

        [parameter(Mandatory = $false)]
        [string]$MobilePhone,

        [parameter(Mandatory = $false)]
        [string]$CostCenter,
            
        [parameter(Mandatory = $false)]
        [string]$Manager,

        [parameter(Mandatory = $false)]
        [string]$Notification,

        [parameter(Mandatory = $false)]
        [string]$Department,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$TimeFormat,

        [parameter(Mandatory = $false)]
        [string]$Zip,

        [parameter(Mandatory = $false)]
        [string]$SsoSource,

        [parameter(Mandatory = $false)]
        [bool]$Vip,

        [parameter(Mandatory = $false)]
        [bool]$EnableMultifactorAuthentication,

        [parameter(Mandatory = $false)]
        [string]$ContractType
    )
        
    $userRequestBuilder = $ServiceNowClient.Users()
    $user = New-Object -TypeName ServiceNow.Graph.Models.User
    $parameters = $MyInvocation.BoundParameters  
            
    if ($parameters.ContainsKey("ApprovalThreshold")) {
        $user.ApprovalThreshold = $ApprovalThreshold
    } 
    if ($parameters.ContainsKey("Active")) {
        $user.Active = $Active
    }
    if ($parameters.ContainsKey("HomePhone")) {
        $user.HomePhone = $HomePhone
    }
    if ($parameters.ContainsKey("CalendarIntegration")) {
        $user.CalendarIntegration = $CalendarIntegration
    }
    if ($parameters.ContainsKey("Division")) {
        $user.Division = $Division
    }
    if ($parameters.ContainsKey("Country")) {
        $user.Country = $Country
    }
    if ($parameters.ContainsKey("UserSecret")) {
        $user.UserPassword = $UserSecret
    }
    if ($parameters.ContainsKey("Source")) {
        $user.Source = $Source
    }
    if ($parameters.ContainsKey("State")) {
        $user.State = $State
    }
    if ($parameters.ContainsKey("FirstName")) {
        $user.FirstName = $FirstName
    }
    if ($parameters.ContainsKey("MiddleName")) {
        $user.MiddleName = $MiddleName
    }
    if ($parameters.ContainsKey("LastName")) {
        $user.LastName = $LastName
    }       
    if ($parameters.ContainsKey("EmployeeNumber")) {
        $user.EmployeeNumber = $EmployeeNumber
    } 
    if ($parameters.ContainsKey("Gender")) {
        $user.Gender = $Gender
    } 
    if ($parameters.ContainsKey("UserName")) {
        $user.UserName = $UserName
    } 
    if ($parameters.ContainsKey("DateFormat")) {
        $user.DateFormat = $DateFormat
    } 
    if ($parameters.ContainsKey("TimeZone")) {
        $user.TimeZone = $TimeZone
    } 
    if ($parameters.ContainsKey("City")) {
        $user.City = $City
    } 
    if ($parameters.ContainsKey("Title")) {
        $user.Title = $Title
    } 
    if ($parameters.ContainsKey("InternalIntegrationUser")) {
        $user.InternalIntegrationUser = $InternalIntegrationUser
    } 
    if ($parameters.ContainsKey("Street")) {
        $user.Street = $Street
    } 
    if ($parameters.ContainsKey("Email")) {
        $user.Email = $Email
    } 
    if ($parameters.ContainsKey("Introduction")) {
        $user.Introduction = $Introduction
    } 
    if ($parameters.ContainsKey("PreferredLanguage")) {
        $user.PreferredLanguage = $PreferredLanguage
    } 
    if ($parameters.ContainsKey("Phone")) {
        $user.Phone = $Phone
    } 
    if ($parameters.ContainsKey("MobilePhone")) {
        $user.MobilePhone = $MobilePhone
    } 
    if ($parameters.ContainsKey("CostCenter")) {
        $user.CostCenter = Get-ReferenceLink $CostCenter
    } 
    if ($parameters.ContainsKey("Manager")) {
        $user.Manager = Get-ReferenceLink $Manager
    } 
    if ($parameters.ContainsKey("Notification")) {
        $user.Notification = $Notification
    } 
    if ($parameters.ContainsKey("Company")) {
        $user.Company = Get-ReferenceLink $Company
    } 
    if ($parameters.ContainsKey("Department")) {
        $user.Department = Get-ReferenceLink $Department
    } 
    if ($parameters.ContainsKey("Location")) {
        $user.Location = Get-ReferenceLink $Location
    } 
    if ($parameters.ContainsKey("TimeFormat")) {
        $user.TimeFormat = $TimeFormat
    } 
    if ($parameters.ContainsKey("Zip")) {
        $user.Zip = $Zip
    } 
    if ($parameters.ContainsKey("Vip")) {
        $user.Vip = $Vip
    } 
    if ($parameters.ContainsKey("EnableMultifactorAuthentication")) {
        $user.EnableMultifactorAuthentication = $EnableMultifactorAuthentication
    } 

     $userRequestBuilder.Request().AddAsync($user).GetAwaiter().GetResult()
}     

function Remove-SnowUser {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
        
    $ServiceNowClient.Users()[$id].DeleteAsync().GetAwaiter().GetResult() | Out-Null
}         

function Set-SnowUser {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$ApprovalThreshold,

        [parameter(Mandatory = $false)]
        [bool]$Active,            

        [parameter(Mandatory = $false)]
        [string]$HomePhone,

        [parameter(Mandatory = $false)]
        [int]$CalendarIntegration,
            
        [parameter(Mandatory = $false)]
        [string]$Country,

        [parameter(Mandatory = $false)]
        [string]$UserSecret,

        [parameter(Mandatory = $false)]
        [string]$Source,

        [parameter(Mandatory = $false)]
        [string]$State,

        [parameter(Mandatory = $false)]
        [string]$FirstName,

        [parameter(Mandatory = $false)]
        [string]$MiddleName,

        [parameter(Mandatory = $false)]
        [string]$LastName,

        [parameter(Mandatory = $false)]
        [string]$EmployeeNumber,

        [parameter(Mandatory = $false)]
        [string]$Gender,
            
        [parameter(Mandatory = $false)]
        [string]$UserName,
            
        [parameter(Mandatory = $false)]
        [string]$DateFormat,
            
        [parameter(Mandatory = $false)]
        [string]$TimeZone,

        [parameter(Mandatory = $false)]
        [string]$City,

        [parameter(Mandatory = $false)]
        [string]$Title,

        [parameter(Mandatory = $false)]
        [bool]$InternalIntegrationUser,

        [parameter(Mandatory = $false)]
        [string]$Street,

        [parameter(Mandatory = $false)]
        [string]$Email,

        [parameter(Mandatory = $false)]
        [string]$Introduction,

        [parameter(Mandatory = $false)]
        [string]$PreferredLanguage,

        [parameter(Mandatory = $false)]
        [string]$Phone,

        [parameter(Mandatory = $false)]
        [string]$MobilePhone,

        [parameter(Mandatory = $false)]
        [string]$CostCenter,
            
        [parameter(Mandatory = $false)]
        [string]$Manager,

        [parameter(Mandatory = $false)]
        [string]$Notification,

        [parameter(Mandatory = $false)]
        [string]$Department,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$TimeFormat,

        [parameter(Mandatory = $false)]
        [string]$Zip,

        [parameter(Mandatory = $false)]
        [string]$SsoSource,

        [parameter(Mandatory = $false)]
        [bool]$Vip,

        [parameter(Mandatory = $false)]
        [bool]$EnableMultifactorAuthentication,

        [parameter(Mandatory = $false)]
        [string]$ContractType,

        [parameter(Mandatory = $false)]
        [string]$Division,

        [parameter(Mandatory = $false)]
        [bool]$LockedOut

    )
        
    $userRequestBuilder = $ServiceNowClient.Users()[$Id] 
    $userUpdate = New-Object -TypeName ServiceNow.Graph.Models.User
    $parameters = $MyInvocation.BoundParameters  
    $userUpdate.Id = $Id
            
    if ($parameters.ContainsKey("ApprovalThreshold")) {
        $userUpdate.ApprovalThreshold = $ApprovalThreshold
    } 
    if ($parameters.ContainsKey("Active")) {
        $userUpdate.Active = $Active
    }
    if ($parameters.ContainsKey("LockedOut")) {
        $userUpdate.LockedOut = $LockedOut
    }    
    if ($parameters.ContainsKey("HomePhone")) {
        $userUpdate.HomePhone = $HomePhone
    }
    if ($parameters.ContainsKey("ContractType")) {
        $userUpdate.ContractType = $ContractType
    }
    if ($parameters.ContainsKey("CalendarIntegration")) {
        $userUpdate.CalendarIntegration = $CalendarIntegration
    }
    if ($parameters.ContainsKey("Country")) {
        $userUpdate.Country = $Country
    }
    if ($parameters.ContainsKey("UserSecret")) {
        $userUpdate.UserPassword = $UserSecret
    }
    if ($parameters.ContainsKey("Source")) {
        $userUpdate.Source = $Source
    }
    if ($parameters.ContainsKey("State")) {
        $userUpdate.State = $State
    }
    if ($parameters.ContainsKey("FirstName")) {
        $userUpdate.FirstName = $FirstName
    }
    if ($parameters.ContainsKey("MiddleName")) {
        $userUpdate.MiddleName = $MiddleName
    }
    if ($parameters.ContainsKey("LastName")) {
        $userUpdate.LastName = $LastName
    }       
    if ($parameters.ContainsKey("EmployeeNumber")) {
        $userUpdate.EmployeeNumber = $EmployeeNumber
    } 
    if ($parameters.ContainsKey("Gender")) {
        $userUpdate.Gender = $Gender
    } 
    if ($parameters.ContainsKey("UserName")) {
        $userUpdate.UserName = $UserName
    } 
    if ($parameters.ContainsKey("DateFormat")) {
        $userUpdate.DateFormat = $DateFormat
    } 
    if ($parameters.ContainsKey("TimeZone")) {
        $userUpdate.TimeZone = $TimeZone
    } 
    if ($parameters.ContainsKey("City")) {
        $userUpdate.City = $City
    } 
    if ($parameters.ContainsKey("Title")) {
        $userUpdate.Title = $Title
    } 
    if ($parameters.ContainsKey("InternalIntegrationUser")) {
        $userUpdate.InternalIntegrationUser = $InternalIntegrationUser
    } 
    if ($parameters.ContainsKey("Street")) {
        $userUpdate.Street = $Street
    } 
    if ($parameters.ContainsKey("Email")) {
        $userUpdate.Email = $Email
    } 
    if ($parameters.ContainsKey("Introduction")) {
        $userUpdate.Introduction = $Introduction
    } 
    if ($parameters.ContainsKey("PreferredLanguage")) {
        $userUpdate.PreferredLanguage = $PreferredLanguage
    } 
    if ($parameters.ContainsKey("Phone")) {
        $userUpdate.Phone = $Phone
    } 
    if ($parameters.ContainsKey("Division")) {
        $userUpdate.Division = $Division
    }    
    if ($parameters.ContainsKey("MobilePhone")) {
        $userUpdate.MobilePhone = $MobilePhone
    } 
    if ($parameters.ContainsKey("CostCenter")) {
        $userUpdate.CostCenter = Get-ReferenceLink $CostCenter
    } 
    if ($parameters.ContainsKey("Manager")) {
        $userUpdate.Manager = Get-ReferenceLink $Manager
    } 
    if ($parameters.ContainsKey("Notification")) {
        $userUpdate.Notification = $Notification
    } 
    if ($parameters.ContainsKey("Company")) {
        $userUpdate.Company = Get-ReferenceLink $Company
    } 
    if ($parameters.ContainsKey("Department")) {
        $userUpdate.Department = Get-ReferenceLink $Department
    } 
    if ($parameters.ContainsKey("Location")) {
        $userUpdate.Location = Get-ReferenceLink $Location
    } 
    if ($parameters.ContainsKey("TimeFormat")) {
        $userUpdate.TimeFormat = $TimeFormat
    } 
    if ($parameters.ContainsKey("Zip")) {
        $userUpdate.Zip = $Zip
    } 
    if ($parameters.ContainsKey("Vip")) {
        $userUpdate.Vip = $Vip
    } 
    if ($parameters.ContainsKey("EnableMultifactorAuthentication")) {
        $userUpdate.EnableMultifactorAuthentication = $EnableMultifactorAuthentication
    } 

   $userRequestBuilder.Request().UpdateAsync($userUpdate).GetAwaiter().GetResult()
}     
   
function Get-SnowGroup {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,

        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
    )
    
        Get-Entity -CollectionBuilder $ServiceNowClient.UserGroups() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}    

function Set-SnowGroup {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$DefaultAssignee,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [bool]$Active,            

        [parameter(Mandatory = $false)]
        [bool]$ExcludeManager,

        [parameter(Mandatory = $false)]
        [string]$HourlyRate,
            
        [parameter(Mandatory = $false)]
        [bool]$IncludeMembers,

        [parameter(Mandatory = $false)]
        [string]$Manager,

        [parameter(Mandatory = $false)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$ParentGroup,

        [parameter(Mandatory = $false)]
        [string]$Roles,

        [parameter(Mandatory = $false)]
        [string]$Source,

        [parameter(Mandatory = $false)]
        [string]$Type,

        [parameter(Mandatory = $false)]
        [string]$Email,

        [parameter(Mandatory = $false)]
        [string]$CostCenter
    )
        
    $groupRequestBuilder = $ServiceNowClient.UserGroups()[$Id] 
    $group = New-Object -TypeName ServiceNow.Graph.Models.UserGroup
    $parameters = $MyInvocation.BoundParameters  
    $group.Id = $Id


    if ($parameters.ContainsKey("Active")) {
        $group.Active = $Active
    }
    if ($parameters.ContainsKey("CostCenter")) {
        if (-not [string]::IsNullOrEmpty($CostCenter)) {
            $group.CostCenter = Get-ReferenceLink $CostCenter
        }
        else {
            $group.CostCenter = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("Description")) {
        $group.Description = $Description
    } 
    if ($parameters.ContainsKey("DefaultAssignee")) {
        if (-not [string]::IsNullOrEmpty($DefaultAssignee)) {
            $group.DefaultAssignee = Get-ReferenceLink $DefaultAssignee
        }
        else {
            $group.DefaultAssignee = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("Email")) {
        $group.Email = $Email
    } 
    if ($parameters.ContainsKey("ExcludeManager")) {
        $group.ExcludeManager = $ExcludeManager
    }
    if ($parameters.ContainsKey("HourlyRate")) {
        $group.HourlyRate = $HourlyRate
    }
    if ($parameters.ContainsKey("IncludeMembers")) {
        $group.IncludeMembers = $IncludeMembers
    }
    if ($parameters.ContainsKey("Name")) {
        $group.Name = $Name
    }
    if ($parameters.ContainsKey("Manager")) {
        if (-not [string]::IsNullOrEmpty($Manager)) {
            $group.Manager = Get-ReferenceLink $Manager
        }
        else {
            $group.Manager = Get-ReferenceLink ""
        }
    } 
    if ($parameters.ContainsKey("Roles")) {
        $group.Roles = $Roles
    } 
    if ($parameters.ContainsKey("ParentGroup")) {
        if (-not [string]::IsNullOrEmpty($ParentGroup)) {
            $group.Parent = Get-ReferenceLink $ParentGroup
        }
        else {
            $group.Parent = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("Source")) {
        $group.Source = $Source
    }
    if ($parameters.ContainsKey("Type")) {
        $group.Type = $Type
    }

    $groupRequestBuilder.Request().UpdateAsync($group).GetAwaiter().GetResult()
}         

function New-SnowGroup {
    param (
        [parameter(Mandatory = $false)]
        [string]$DefaultAssignee,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [bool]$Active,            

        [parameter(Mandatory = $false)]
        [bool]$ExcludeManager,

        [parameter(Mandatory = $false)]
        [string]$HourlyRate,
        
        [parameter(Mandatory = $false)]
        [bool]$IncludeMembers,

        [parameter(Mandatory = $false)]
        [string]$Manager,

        [parameter(Mandatory = $false)]
        [string]$Name,

        [parameter(Mandatory = $false)]
        [string]$ParentGroup,

        [parameter(Mandatory = $false)]
        [string]$Roles,

        [parameter(Mandatory = $false)]
        [string]$Source,

        [parameter(Mandatory = $false)]
        [string]$Type,

        [parameter(Mandatory = $false)]
        [string]$Email,

        [parameter(Mandatory = $false)]
        [string]$CostCenter
    )
    
    $groupRequestBuilder = $ServiceNowClient.UserGroups()
    $group = New-Object -TypeName ServiceNow.Graph.Models.UserGroup
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("Active")) {
        $group.Active = $Active
    }
    if ($parameters.ContainsKey("CostCenter")) {
        if (-not [string]::IsNullOrEmpty($CostCenter)) {
            $group.CostCenter = Get-ReferenceLink $CostCenter
        }
        else {
            $group.CostCenter = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("Description")) {
        $group.Description = $Description
    } 
    if ($parameters.ContainsKey("DefaultAssignee")) {
        if (-not [string]::IsNullOrEmpty($DefaultAssignee)) {
            $group.DefaultAssignee = Get-ReferenceLink $DefaultAssignee
        }
        else {
            $group.DefaultAssignee = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("Email")) {
        $group.Email = $Email
    } 
    if ($parameters.ContainsKey("ExcludeManager")) {
        $group.ExcludeManager = $ExcludeManager
    }
    if ($parameters.ContainsKey("HourlyRate")) {
        $group.HourlyRate = $HourlyRate
    }
    if ($parameters.ContainsKey("IncludeMembers")) {
        $group.IncludeMembers = $IncludeMembers
    }
    if ($parameters.ContainsKey("Name")) {
        $group.Name = $Name
    }
    if ($parameters.ContainsKey("Manager")) {
        if (-not [string]::IsNullOrEmpty($Manager)) {
            $group.Manager = Get-ReferenceLink $Manager
        }
        else {
            $group.Manager = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("Roles")) {
        $group.Roles = $Roles
    } 
    if ($parameters.ContainsKey("ParentGroup")) {
        if (-not [string]::IsNullOrEmpty($ParentGroup)) {
            $group.Parent = Get-ReferenceLink $ParentGroup
        }
        else {
            $group.Parent = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("Source")) {
        $group.Source = $Source
    }
    if ($parameters.ContainsKey("Type")) {
        $group.Type = $Type
    }

    $groupRequestBuilder.Request().AddAsync($group).GetAwaiter().GetResult()
}         

function Remove-SnowGroup {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.UserGroups()[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
}         

function Get-SnowGroupMembership {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id,
        
        [parameter(Mandatory = $false)]
        [String]$Filter,

        [parameter(Mandatory = $false)]
        [String]$Select,

        [parameter(Mandatory = $false)]
        [String]$OrderBy
        
        
    )
        
   Get-Entity -CollectionBuilder $ServiceNowClient.Memberships() -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
}        

function New-SnowGroupMembership {
    param (
        [parameter(Mandatory = $true)]
        [string]$Group,

        [parameter(Mandatory = $true)]
        [string]$User
    )
    
    $membershipsRequestBuilder = $ServiceNowClient.Memberships
    $membership = New-Object -TypeName ServiceNow.Graph.Models.UserGroupMembership


    $membership.User = Get-ReferenceLink $User
    $membership.Group = Get-ReferenceLink $Group

    $membershipsRequestBuilder.Request().AddAsync($membership).GetAwaiter().GetResult()
}         

function Remove-SnowGroupMembership {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.Memberships()[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
}         
function Get-ServiceNowClient {
    param (
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $false)]
        [ValidateNotNullOrEmpty()]
        [String]$Domain,

        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $false)]
        [ValidateNotNullOrEmpty()]
        [String]$ClientId, 

        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $false)]
        [ValidateNotNullOrEmpty()]
        [securestring]$ClientSecret,        

        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $false)]
        [ValidateNotNullOrEmpty()]
        [ValidateScript( { if ( -Not (Test-Path -Path $_) ) {
                    throw "File $_  does not exist"
                }
                return $true })]
        [String]$LibraryPath, 

        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $false)]
        [ValidateNotNullOrEmpty()]
        [String]$UserName, 

        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $false)]
        [ValidateNotNullOrEmpty()]
        [securestring]$UserPassword,		

        [parameter(Mandatory = $false, ValueFromPipelineByPropertyName = $false)]
        [Int]$PageSize = 1000
    )

    if ($null -eq $Global:ServiceNowClient) {
        # Initialize the client
        $plainClientSecret = ""
        $ptr = [System.IntPtr]::Zero
        try {
            $ptr = [System.IntPtr]::Zero    
            $ptr = [System.Runtime.InteropServices.Marshal]::SecureStringToGlobalAllocUnicode($ClientSecret)
            $plainClientSecret = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($ptr)
        }
        finally {
            [System.Runtime.InteropServices.Marshal]::ZeroFreeGlobalAllocUnicode($ptr)
        }
        $plainUserPassword = ""
        $ptrUserPassword = [System.IntPtr]::Zero
        try {
            $ptrUserPassword = [System.IntPtr]::Zero    
            $ptrUserPassword = [System.Runtime.InteropServices.Marshal]::SecureStringToGlobalAllocUnicode($UserPassword)
            $plainUserPassword = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($ptrUserPassword)
        }
        finally {
            [System.Runtime.InteropServices.Marshal]::ZeroFreeGlobalAllocUnicode($ptrUserPassword)
        }		  
        Add-Type -Path $LibraryPath
        $authenticationProvider = New-Object -TypeName ServiceNow.Graph.Authentication.ClientCredentialProvider -ArgumentList $Domain, $ClientId, $plainClientSecret, $UserName, $plainUserPassword
        # Last parameter is the version that is mangled in the API Gateway URL
        $Global:ServiceNowClient = New-Object -TypeName ServiceNow.Graph.Requests.ServiceNowClient -ArgumentList $Domain, $authenticationProvider, $null
        $Global:PageSize = $PageSize
    }
}
function Remove-ServiceNowClient {
    #$Global:ServiceNowClient = $null
}