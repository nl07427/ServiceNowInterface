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
        [nullable[datetime]]$ValidFrom,

        [parameter(Mandatory = $false)]
        [nullable[datetime]]$ValidTo        
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
        if ($ValidFrom -ne [DateTime]::MinValue) {
            $costcenter.ValidFrom = $ValidFrom.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $costcenter.ValidFrom = [datetime]::MinValue
        }
    }                                 
    if ($parameters.ContainsKey("ValidTo") -and $ValidTo) {
        if ($ValidTo -ne [DateTime]::MinValue) {
            $costcenter.ValidTo = $ValidTo.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $costcenter.ValidTo = [datetime]::MinValue
        }
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
        [nullable[datetime]]$ValidFrom,

        [parameter(Mandatory = $false)]
        [nullable[datetime]]$ValidTo        
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
    if ($parameters.ContainsKey("ValidFrom") -and $ValidFrom) {
        if ($ValidFrom -ne [DateTime]::MinValue) {
            $costcenter.ValidFrom = $ValidFrom.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $costcenter.ValidFrom = [datetime]::MinValue
        }
    }                                 
    if ($parameters.ContainsKey("ValidTo") -and $ValidTo) {
        if ($ValidTo -ne [DateTime]::MinValue) {
            $costcenter.ValidTo = $ValidTo.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $costcenter.ValidTo = [datetime]::MinValue
        }
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
        [nullable[datetime]]$CoordinatesRetrievedOn,

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
    if ($parameters.ContainsKey("CoordinatesRetrievedOn") -and $CoordinatesRetrievedOn) {
        if ($CoordinatesRetrievedOn -ne [DateTime]::MinValue) {
            $location.CoordinatesRetrievedOn = $CoordinatesRetrievedOn.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $location.CoordinatesRetrievedOn = [datetime]::MinValue
        }
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
        [nullable[datetime]]$CoordinatesRetrievedOn,

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
    if ($parameters.ContainsKey("CoordinatesRetrievedOn") -and $CoordinatesRetrievedOn) {
        if ($CoordinatesRetrievedOn -ne [DateTime]::MinValue) {
            $location.CoordinatesRetrievedOn = $CoordinatesRetrievedOn.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $location.CoordinatesRetrievedOn = [datetime]::MinValue
        }
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
        [nullable[datetime]]$CoordinatesRetrievedOn,

        [parameter(Mandatory = $false)]
        [string]$Country,

        [parameter(Mandatory = $false)]
        [bool]$Customer,

        [parameter(Mandatory = $false)]
        [string]$Discount,        

        [parameter(Mandatory = $false)]
        [string]$FaxPhone,

        [parameter(Mandatory = $false)]
        [nullable[datetime]]$FiscalYear,

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
    if ($parameters.ContainsKey("CoordinatesRetrievedOn") -and $CoordinatesRetrievedOn) {
        if ($CoordinatesRetrievedOn -ne [DateTime]::MinValue) {
            $company.CoordinatesRetrievedOn = $CoordinatesRetrievedOn.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $company.CoordinatesRetrievedOn = [datetime]::MinValue
        }
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
    if ($parameters.ContainsKey("FiscalYear") -and $FiscalYear) {
        if ($FiscalYear -ne [DateTime]::MinValue) {
            $company.FiscalYear = $FiscalYear.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $company.FiscalYear = [datetime]::MinValue
        }
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
        [nullable[datetime]]$CoordinatesRetrievedOn,

        [parameter(Mandatory = $false)]
        [string]$Country,

        [parameter(Mandatory = $false)]
        [bool]$Customer,

        [parameter(Mandatory = $false)]
        [string]$Discount,        

        [parameter(Mandatory = $false)]
        [string]$FaxPhone,

        [parameter(Mandatory = $false)]
        [nullable[datetime]]$FiscalYear,

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
    if ($parameters.ContainsKey("Contact") -and $Contact) {
        $company.Contact = Get-ReferenceLink $Contact
    }        
    if ($parameters.ContainsKey("CoordinatesRetrievedOn") -and $CoordinatesRetrievedOn) {
        if ($CoordinatesRetrievedOn -ne [DateTime]::MinValue) {
            $company.CoordinatesRetrievedOn = $CoordinatesRetrievedOn.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $company.CoordinatesRetrievedOn = [datetime]::MinValue
        }
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
    if ($parameters.ContainsKey("FiscalYear") -and $FiscalYear) {
        if ($FiscalYear -ne [DateTime]::MinValue) {
            $company.FiscalYear = $FiscalYear.ToString("yyyy-MM-dd HH:mm:ss")
        } else {
            $company.FiscalYear = [datetime]::MinValue
        }
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
    if ($parameters.ContainsKey("CausedBy") -and $CausedBy) {
        $incident.CausedBy = Get-ReferenceLink $CausedBy
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
        [string]$ShortDescription,
        [parameter(Mandatory = $false)]
        [string]$Photo,
            
        [parameter(Mandatory = $true)]
        [string]$Table,
        
        [parameter(Mandatory = $true)]
        [string]$Name,
        
        [parameter(Mandatory = $true)]
        [string]$Type
    )
    
    $profileRequestBuilder = $ServiceNowClient.LiveProfiles()
    $liveProfile = New-Object -TypeName ServiceNow.Graph.Models.LiveProfile
    $parameters = $MyInvocation.BoundParameters  
    if ($parameters.ContainsKey("Document")) {
        if (-not [string]::IsNullOrEmpty($Document)) {
            $liveProfile.Document = Get-ReferenceLink $Document
        }
        else {
            $liveProfile.Document = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("ShortDescription")) {
        $liveProfile.ShortDescription = $ShortDescription
    } 
    if ($parameters.ContainsKey("Photo")) {
        $liveProfile.Photo = $Photo
    }
    if ($parameters.ContainsKey("Table")) {
        $liveProfile.Table = $Table
    }
    if ($parameters.ContainsKey("Type")) {
        $liveProfile.Type = $Type
    }
    $liveProfile.Name = $Name

    $profileRequestBuilder.Request().AddAsync($liveProfile).GetAwaiter().GetResult()
}         

function Set-SnowLiveProfile {
    param (
      [parameter(Mandatory = $true)]
      [string]$Id,
      [parameter(Mandatory = $false)]
      [string]$Document,
      [parameter(Mandatory = $false)]
      [string]$ShortDescription,
      [parameter(Mandatory = $false)]
      [string]$Photo,
      [parameter(Mandatory = $false)]
      [string]$Name,
      [parameter(Mandatory = $false)]
      [string]$Table,
      [parameter(Mandatory = $false)]
      [string]$Type
  )
  $profileRequestBuilder = $ServiceNowClient.LiveProfiles()[$Id] 
  $liveProfile = New-Object -TypeName ServiceNow.Graph.Models.LiveProfile
  $parameters = $MyInvocation.BoundParameters  
  $liveProfile.Id = $Id
  if ($parameters.ContainsKey("Document")) {​
      if (-not [string]::IsNullOrEmpty($Document)) {​
          $liveProfile.Document = Get-ReferenceLink $Document
      }​
      else {​
          $liveProfile.Document = [ServiceNow.Graph.Models.ReferenceLink]$null
      }​
  }​ 
  if ($parameters.ContainsKey("ShortDescription")) {​
      $liveProfile.ShortDescription = $ShortDescription
  }​ 
  if ($parameters.ContainsKey("Photo")) {​
      $liveProfile.Photo = $Photo
  }​
  if ($parameters.ContainsKey("Table")) {​
      $liveProfile.Table = $Table
  }​
  if ($parameters.ContainsKey("Type")) {​
      $liveProfile.Type = $Type
  }​
  if ($parameters.ContainsKey("Name")) {​
      $liveProfile.Name = $Name
  }​
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
        [parameter(Mandatory = $true)]
        [string]$Variable,

        [parameter(Mandatory = $false)]
        [string]$ItemOption,

        [parameter(Mandatory = $false)]
        [string]$CartItem,

        [parameter(Mandatory = $false)]
        [string]$Value
    )
        
    $catalogOptionsRequestBuilder = $ServiceNowClient.CatalogOptions()
    $option = New-Object -TypeName ServiceNow.Graph.Models.CatalogOptions
    $parameters = $MyInvocation.BoundParameters  
            
    $option.Variable =  Get-ReferenceLink $Variable

    if ($parameters.ContainsKey("ItemOption")) {
        if (-not [string]::IsNullOrEmpty($ItemOption)) {
            $option.ItemOption = Get-ReferenceLink $ItemOption
        }
        else {
            $option.ItemOption = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     

    if ($parameters.ContainsKey("CartItem")) {
        if (-not [string]::IsNullOrEmpty($CartItem)) {
            $option.CartItem = Get-ReferenceLink $CartItem
        }
        else {
            $option.ItemOption = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
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
        [string]$Value,

        [parameter(Mandatory = $false)]
        [string]$ItemOption,

        [parameter(Mandatory = $false)]
        [string]$CartItem
    )
        
    $catalogOptionsRequestBuilder = $ServiceNowClient.CatalogOptions()[$Id] 
    $option = New-Object -TypeName ServiceNow.Graph.Models.CatalogOptions
    $parameters = $MyInvocation.BoundParameters  
    $option.Id = $Id
            
    if ($parameters.ContainsKey("Value")) {
        $option.Value = $Value
    } 
    
    if ($parameters.ContainsKey("ItemOption")) {
        if (-not [string]::IsNullOrEmpty($ItemOption)) {
            $option.ItemOption = Get-ReferenceLink $ItemOption
        }
        else {
            $option.ItemOption = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     

    if ($parameters.ContainsKey("CartItem")) {
        if (-not [string]::IsNullOrEmpty($CartItem)) {
            $option.CartItem = Get-ReferenceLink $CartItem
        }
        else {
            $option.ItemOption = [ServiceNow.Graph.Models.ReferenceLink]$null
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
        [string]$CatalogItemOption,

        [parameter(Mandatory = $true)]
        [string]$CatalogRequestItem

    )
        
    $variableOwnershipBuilder = $ServiceNowClient.VariableOwnerships()
    $variableOwnership = New-Object -TypeName ServiceNow.Graph.Models.CatalogItemOptionMtom
            
    $variableOwnership.CatalogItemOption =  Get-ReferenceLink $CatalogItemOption
    $variableOwnership.CatalogRequestItem =  Get-ReferenceLink $CatalogRequestItem

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
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$OpenedBy,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [string]$Price,

        [parameter(Mandatory = $false)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DeliveryAddress,        

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        
        
        [parameter(Mandatory = $false)]
        [string]$SpecialInstructions,

        [parameter(Mandatory = $false)]
        [datetime]$RequestedForDate
    )
    
    $requestBuilder = $ServiceNowClient.CatalogRequests()
    $request = New-Object -TypeName ServiceNow.Graph.Models.CatalogRequest
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("Active")) {
        $request.Active = $Active
    }

    if ($parameters.ContainsKey("Knowledge")) {
        $request.Knowledge = $Knowledge
    }

    if ($parameters.ContainsKey("DeliveryAddress")) {
        $request.DeliveryAddress = $DeliveryAddress
    }

    if ($parameters.ContainsKey("Price")) {
        $request.Price = $Price
    }

    if ($parameters.ContainsKey("Urgency")) {
        $request.Urgency = $Urgency
    }

    if ($parameters.ContainsKey("Impact")) {
        $request.Impact = $Impact
    }

    if ($parameters.ContainsKey("Priority")) {
        $request.Priority = $Priority
    }
    if ($parameters.ContainsKey("CloseNotes")) {
        $request.CloseNotes = $CloseNotes
    } 

    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $request.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Description")) {
        $request.Description = $Description
    }         
    if ($parameters.ContainsKey("SpecialInstructions")) {
        $request.SpecialInstructions = $SpecialInstructions
    }             
    
    if ($parameters.ContainsKey("AssignedTo")) {
        if (-not [string]::IsNullOrEmpty($AssignedTo)) {
            $request.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $request.AssignedTo = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          

    if ($parameters.ContainsKey("ClosedBy")) {
        if (-not [string]::IsNullOrEmpty($ClosedBy)) {
            $request.ClosedBy = Get-ReferenceLink $ClosedBy
        }
        else {
            $request.ClosedBy = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          

    if ($parameters.ContainsKey("Company")) {
        if (-not [string]::IsNullOrEmpty($Company)) {
            $request.Company = Get-ReferenceLink $Company
        }
        else {
            $request.Company = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
    if ($parameters.ContainsKey("ServiceOffering")) {
        if (-not [string]::IsNullOrEmpty($ServiceOffering)) {
            $request.ServiceOffering = Get-ReferenceLink $ServiceOffering
        }
        else {
            $request.ServiceOffering = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
    if ($parameters.ContainsKey("SpecialInstructions")) {
        $request.SpecialInstructions = $SpecialInstructions
    }             
    if ($parameters.ContainsKey("BusinessService")) {
        if (-not [string]::IsNullOrEmpty($BusinessService)) {
            $request.BusinessService = Get-ReferenceLink $BusinessService
        }
        else {
            $request.BusinessService = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
            
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if (-not [string]::IsNullOrEmpty($AssignmentGroup)) {
            $request.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $request.AssignmentGroup = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     
          
    if ($parameters.ContainsKey("Comments")) {
        $request.Comments = $Comments
    }
    if ($parameters.ContainsKey("ContactType")) {
        $request.ContactType = $ContactType
    }    
              
    if ($parameters.ContainsKey("Location")) {
        if (-not [string]::IsNullOrEmpty($Location)) {
            $request.Location = Get-ReferenceLink $Location
        }
        else {
            $request.Location = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }

    if ($parameters.ContainsKey("OpenedBy")) {
        if (-not [string]::IsNullOrEmpty($OpenedBy)) {
            $request.OpenedBy = Get-ReferenceLink $OpenedBy
        }
        else {
            $request.OpenedBy = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }
                                   
    if ($parameters.ContainsKey("State")) {
        $request.State = $State
    }   
               
    if ($parameters.ContainsKey("ShortDescription")) {
        $request.ShortDescription = $ShortDescription
    }

    if ($parameters.ContainsKey("RequestedFor")) {
        if (-not [string]::IsNullOrEmpty($RequestedFor)) {
            $request.RequestedFor = Get-ReferenceLink $RequestedFor
        }
        else {
            $request.RequestedFor = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
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
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [string]$Price,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,        

        [parameter(Mandatory = $false)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$Description,        

        [parameter(Mandatory = $false)]
        [string]$DeliveryAddress,        
        
        [parameter(Mandatory = $false)]
        [string]$SpecialInstructions,

        [parameter(Mandatory = $false)]
        [datetime]$RequestedForDate
        
    )
    
    $requestBuilder = $ServiceNowClient.CatalogRequests()[$Id] 
    $request = New-Object -TypeName ServiceNow.Graph.Models.CatalogRequest
    $parameters = $MyInvocation.BoundParameters  
    $request.Id = $Id

    if ($parameters.ContainsKey("Active")) {
        $request.Active = $Active
    }
    
    if ($parameters.ContainsKey("Knowledge")) {
        $request.Knowledge = $Knowledge
    }

    if ($parameters.ContainsKey("DeliveryAddress")) {
        $request.DeliveryAddress = $DeliveryAddress
    }

    if ($parameters.ContainsKey("Price")) {
        $request.Price = $Price
    }

    if ($parameters.ContainsKey("Urgency")) {
        $request.Urgency = $Urgency
    }

    if ($parameters.ContainsKey("Impact")) {
        $request.Impact = $Impact
    }

    if ($parameters.ContainsKey("Priority")) {
        $request.Priority = $Priority
    }
    if ($parameters.ContainsKey("CloseNotes")) {
        $request.CloseNotes = $CloseNotes
    } 

    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $request.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    if ($parameters.ContainsKey("Description")) {
        $request.Description = $Description
    }         
    if ($parameters.ContainsKey("SpecialInstructions")) {
        $request.SpecialInstructions = $SpecialInstructions
    }             
    
    if ($parameters.ContainsKey("AssignedTo")) {
        if (-not [string]::IsNullOrEmpty($AssignedTo)) {
            $request.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $request.AssignedTo = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          

    if ($parameters.ContainsKey("ClosedBy")) {
        if (-not [string]::IsNullOrEmpty($ClosedBy)) {
            $request.ClosedBy = Get-ReferenceLink $ClosedBy
        }
        else {
            $request.ClosedBy = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          

    if ($parameters.ContainsKey("Company")) {
        if (-not [string]::IsNullOrEmpty($Company)) {
            $request.Company = Get-ReferenceLink $Company
        }
        else {
            $request.Company = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
    if ($parameters.ContainsKey("ServiceOffering")) {
        if (-not [string]::IsNullOrEmpty($ServiceOffering)) {
            $request.ServiceOffering = Get-ReferenceLink $ServiceOffering
        }
        else {
            $request.ServiceOffering = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
    if ($parameters.ContainsKey("SpecialInstructions")) {
        $request.SpecialInstructions = $SpecialInstructions
    }             
    if ($parameters.ContainsKey("BusinessService")) {
        if (-not [string]::IsNullOrEmpty($BusinessService)) {
            $request.BusinessService = Get-ReferenceLink $BusinessService
        }
        else {
            $request.BusinessService = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
            
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if (-not [string]::IsNullOrEmpty($AssignmentGroup)) {
            $request.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $request.AssignmentGroup = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     
          
    if ($parameters.ContainsKey("Comments")) {
        $request.Comments = $Comments
    }
    if ($parameters.ContainsKey("ContactType")) {
        $request.ContactType = $ContactType
    }    
              
    if ($parameters.ContainsKey("Location")) {
        if (-not [string]::IsNullOrEmpty($Location)) {
            $request.Location = Get-ReferenceLink $Location
        }
        else {
            $request.Location = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }

                                  
    if ($parameters.ContainsKey("State")) {
        $request.State = $State
    }   
               
    if ($parameters.ContainsKey("ShortDescription")) {
        $request.ShortDescription = $ShortDescription
    }

    if ($parameters.ContainsKey("RequestedFor")) {
        if (-not [string]::IsNullOrEmpty($RequestedFor)) {
            $request.RequestedFor = Get-ReferenceLink $RequestedFor
        }
        else {
            $request.RequestedFor = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
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
        [parameter(Mandatory = $true)]
        [string]$OpenedBy,

        [parameter(Mandatory = $true)]
        [string]$CatalogItem,

        [parameter(Mandatory = $true)]
        [string]$Request,

        [parameter(Mandatory = $true)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$OrderGuide,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [string]$Price,

        [parameter(Mandatory = $false)]
        [string]$Quantity,

        [parameter(Mandatory = $false)]
        [string]$ConfigurationItem,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi
        
    )
    
    $requestItemsBuilder = $ServiceNowClient.RequestItems()
    $requestItem = New-Object -TypeName ServiceNow.Graph.Models.RequestItem
    $parameters = $MyInvocation.BoundParameters  


    $requestItem.OpenedBy = Get-ReferenceLink $OpenedBy
    $requestItem.RequestedFor = Get-ReferenceLink $RequestedFor
    $requestItem.CatalogItem = Get-ReferenceLink $CatalogItem
    $requestItem.Request = Get-ReferenceLink $Request

    if ($parameters.ContainsKey("Price")) {
        if(-not [string]::IsNullOrEmpty($Price)){
            $requestItem.Price =  $Price
        }
    } 

    if ($parameters.ContainsKey("Quantity")) {
        if(-not [string]::IsNullOrEmpty($Quantity)){
            $requestItem.Quantity =  $Quantity
        }
    } 

    if ($parameters.ContainsKey("Impact")) {
        $requestItem.Impact =  $Impact
    } 
    if ($parameters.ContainsKey("Description")) {
        $requestItem.Description =  $Description
    } 

    if ($parameters.ContainsKey("Urgency")) {
        $requestItem.Urgency =  $Urgency
    } 

    if ($parameters.ContainsKey("Priority")) {
        $requestItem.Priority =  $Priority
    } 

    if ($parameters.ContainsKey("ShortDescription")) {
        $requestItem.ShortDescription =  $ShortDescription
    } 

    if ($parameters.ContainsKey("CmdbCi")) {
        $requestItem.CmdbCi = Get-ReferenceLink $CmdbCi
    } 

    if ($parameters.ContainsKey("ContactType")) {
        $requestItem.ContactType = $ContactType
    } 

    if ($parameters.ContainsKey("Company")) {
        $requestItem.Company = Get-ReferenceLink $Company
    } 

    if ($parameters.ContainsKey("ConfigurationItem")) {
        $requestItem.ConfigurationItem = Get-ReferenceLink $ConfigurationItem
    } 

    if ($parameters.ContainsKey("Location")) {
        $requestItem.Location = Get-ReferenceLink $Location
    } 

    if ($parameters.ContainsKey("AssignedTo")) {
        $requestItem.AssignedTo = Get-ReferenceLink $AssignedTo
    } 

    if ($parameters.ContainsKey("AssignmentGroup")) {
        $requestItem.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
    } 

    if ($parameters.ContainsKey("OrderGuide")) {
        $requestItem.OrderGuide = Get-ReferenceLink $OrderGuide
    } 
    if ($parameters.ContainsKey("Comments")) {
        $requestItem.Comments = $Comments
    } 
    if ($parameters.ContainsKey("Active")) {
        $requestItem.Active = $Active
    } 

    $requestItemsBuilder.Request().AddAsync($requestItem).GetAwaiter().GetResult()
}         

function Set-SnowRequestItem {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$State,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$RequestedFor,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$OrderGuide,

        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [string]$Price,

        [parameter(Mandatory = $false)]
        [string]$Quantity,

        [parameter(Mandatory = $false)]
        [string]$ConfigurationItem,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi

    )
    
    $requestItemsBuilder = $ServiceNowClient.RequestItems()[$Id] 
    $requestItem = New-Object -TypeName ServiceNow.Graph.Models.RequestItem
    $parameters = $MyInvocation.BoundParameters  
    $requestItem.Id = $Id


    if ($parameters.ContainsKey("State")) {
        $requestItem.State = $State
    }
    if ($parameters.ContainsKey("CloseNotes")) {
        $requestItem.CloseNotes = $CloseNotes
    } 

    if ($parameters.ContainsKey("Comments")) {
        $requestItem.Comments = $Comments
    } 

    if ($parameters.ContainsKey("Price")) {
        if(-not [string]::IsNullOrEmpty($Price)){
            $requestItem.Price =  $Price
        }
    } 

    if ($parameters.ContainsKey("Quantity")) {
        if(-not [string]::IsNullOrEmpty($Quantity)){
            $requestItem.Quantity =  $Quantity
        }
    } 

    if ($parameters.ContainsKey("Impact")) {
        $requestItem.Impact =  $Impact
    } 
    if ($parameters.ContainsKey("Description")) {
        $requestItem.Description =  $Description
    } 

    if ($parameters.ContainsKey("Urgency")) {
        $requestItem.Urgency =  $Urgency
    } 

    if ($parameters.ContainsKey("Priority")) {
        $requestItem.Priority =  $Priority
    } 

    if ($parameters.ContainsKey("ShortDescription")) {
        $requestItem.ShortDescription =  $ShortDescription
    } 

    if ($parameters.ContainsKey("CmdbCi")) {
        $requestItem.CmdbCi = Get-ReferenceLink $CmdbCi
    } 

    if ($parameters.ContainsKey("RequestedFor")) {
        $requestItem.RequestedFor = Get-ReferenceLink $RequestedFor
    } 

    if ($parameters.ContainsKey("ContactType")) {
        $requestItem.ContactType = $ContactType
    } 

    if ($parameters.ContainsKey("Company")) {
        $requestItem.Company = Get-ReferenceLink $Company
    } 

    if ($parameters.ContainsKey("ConfigurationItem")) {
        $requestItem.ConfigurationItem = Get-ReferenceLink $ConfigurationItem
    } 

    if ($parameters.ContainsKey("Location")) {
        $requestItem.Location = Get-ReferenceLink $Location
    } 

    if ($parameters.ContainsKey("AssignedTo")) {
        $requestItem.AssignedTo = Get-ReferenceLink $AssignedTo
    } 

    if ($parameters.ContainsKey("AssignmentGroup")) {
        $requestItem.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
    } 

    if ($parameters.ContainsKey("OrderGuide")) {
        $requestItem.OrderGuide = Get-ReferenceLink $OrderGuide
    } 
    if ($parameters.ContainsKey("Comments")) {
        $requestItem.Comments = $Comments
    } 
    if ($parameters.ContainsKey("Active")) {
        $requestItem.Active = $Active
    } 
        
    $requestItemsBuilder.Request().UpdateAsync($requestItem).GetAwaiter().GetResult()
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
        [parameter(Mandatory = $true)]
        [string]$RequestItem,

        [parameter(Mandatory = $true)]
        [string]$Request,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,
        
        [parameter(Mandatory = $false)]
        [int]$State,
        
        [parameter(Mandatory = $false)]
        [bool]$Knowledge,
        
        [parameter(Mandatory = $false)]
        [bool]$Active,
        
        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$Description ,

        [parameter(Mandatory = $false)]
        [string]$BusinessService ,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [string]$Company

)
    
    $requestBuilder = $ServiceNowClient.CatalogTasks()
    $task = New-Object -TypeName ServiceNow.Graph.Models.CatalogTask
    $parameters = $MyInvocation.BoundParameters  

    $task.RequestItem = Get-ReferenceLink $RequestItem
    $task.Request = Get-ReferenceLink $Request
    if ($parameters.ContainsKey("ContactType")) {
        $task.ContactType = $ContactType
    } 

    if ($parameters.ContainsKey("CloseNotes")) {
        $task.CloseNotes = $CloseNotes
    } 

    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $task.AdditionalAssigneeList = $AdditionalAssigneeList
    } 

    if ($parameters.ContainsKey("Priority")) {
        $task.Priority = $Priority
    } 

    if ($parameters.ContainsKey("Active")) {
        $task.Active = $Active
    } 

    if ($parameters.ContainsKey("Knowledge")) {
        $task.Knowledge = $Knowledge
    } 

    if ($parameters.ContainsKey("Description")) {
        $task.Description = $Description
    } 

    if ($parameters.ContainsKey("CmdbCi")) {
        if (-not [string]::IsNullOrEmpty($CmdbCi)) {
            $task.CmdbCi = Get-ReferenceLink $CmdbCi
        }
        else {
            $task.CmdbCi = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 

    if ($parameters.ContainsKey("ServiceOffering")) {
        if (-not [string]::IsNullOrEmpty($ServiceOffering)) {
            $task.ServiceOffering = Get-ReferenceLink $ServiceOffering
        }
        else {
            $task.ServiceOffering = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 

    if ($parameters.ContainsKey("ClosedBy")) {
        if (-not [string]::IsNullOrEmpty($ClosedBy)) {
            $task.ClosedBy = Get-ReferenceLink $ClosedBy
        }
        else {
            $task.ClosedBy = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    
    if ($parameters.ContainsKey("Location")) {
        if (-not [string]::IsNullOrEmpty($Location)) {
            $task.Location = Get-ReferenceLink $Location
        }
        else {
            $task.Location = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    
    if ($parameters.ContainsKey("Company")) {
        if (-not [string]::IsNullOrEmpty($Company)) {
            $task.Company = Get-ReferenceLink $Company
        }
        else {
            $task.Company = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 

    if ($parameters.ContainsKey("BusinessService")) {
        if (-not [string]::IsNullOrEmpty($BusinessService)) {
            $task.BusinessService = Get-ReferenceLink $BusinessService
        }
        else {
            $task.BusinessService = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("AssignedTo")) {
        if (-not [string]::IsNullOrEmpty($AssignedTo)) {
            $task.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $task.AssignedTo = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
            
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if (-not [string]::IsNullOrEmpty($AssignmentGroup)) {
            $task.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $task.AssignmentGroup = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     
          
    if ($parameters.ContainsKey("Comments")) {
        $task.Comments = $Comments
    }

    if ($parameters.ContainsKey("WorkNotes")) {
        $task.WorkNotes = $WorkNotes
    }

    if ($parameters.ContainsKey("Urgency")) {
        $task.Urgency = $Urgency
    }   
 
    if ($parameters.ContainsKey("Impact")) {
        $task.Impact = $Impact
    }   
 
    if ($parameters.ContainsKey("State")) {
        $task.State = $State
    }   
     
    if ($parameters.ContainsKey("ShortDescription")) {
        $task.ShortDescription = $ShortDescription
    }
                
    $requestBuilder.Request().AddAsync($task).GetAwaiter().GetResult()
}         

function Set-SnowCatalogTask {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$Company,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,
        
        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$Description ,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$BusinessService,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$ClosedBy,

        [parameter(Mandatory = $false)]
        [string]$ServiceOffering,

        [parameter(Mandatory = $false)]
        [int]$Impact ,

        [parameter(Mandatory = $false)]
        [int]$Urgency,
        
        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $false)]
        [bool]$Knowledge,

        [parameter(Mandatory = $false)]
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Location

)
    
    $requestBuilder = $ServiceNowClient.CatalogTasks()[$Id] 
    $task = New-Object -TypeName ServiceNow.Graph.Models.CatalogTask
    $parameters = $MyInvocation.BoundParameters  
    $task.Id = $Id


    if ($parameters.ContainsKey("CloseNotes")) {
        $task.CloseNotes = $CloseNotes
    } 

    if ($parameters.ContainsKey("ContactType")) {
        $task.ContactType = $ContactType
    } 

    if ($parameters.ContainsKey("Active")) {
        $task.Active = $Active
    } 

    if ($parameters.ContainsKey("Knowledge")) {
        $task.Knowledge = $Knowledge
    } 
    if ($parameters.ContainsKey("Description")) {
        $task.Description = $Description
    }                 
    
    if ($parameters.ContainsKey("CmdbCi")) {
        if (-not [string]::IsNullOrEmpty($CmdbCi)) {
            $task.CmdbCi = Get-ReferenceLink $CmdbCi
        }
        else {
            $task.CmdbCi = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    
    if ($parameters.ContainsKey("ServiceOffering")) {
        if (-not [string]::IsNullOrEmpty($ServiceOffering)) {
            $task.ServiceOffering = Get-ReferenceLink $ServiceOffering
        }
        else {
            $task.ServiceOffering = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    
    if ($parameters.ContainsKey("ClosedBy")) {
        if (-not [string]::IsNullOrEmpty($ClosedBy)) {
            $task.ClosedBy = Get-ReferenceLink $ClosedBy
        }
        else {
            $task.ClosedBy = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    
    if ($parameters.ContainsKey("Location")) {
        if (-not [string]::IsNullOrEmpty($Location)) {
            $task.Location = Get-ReferenceLink $Location
        }
        else {
            $task.Location = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 

    if ($parameters.ContainsKey("BusinessService")) {
        if (-not [string]::IsNullOrEmpty($BusinessService)) {
            $task.BusinessService = Get-ReferenceLink $BusinessService
        }
        else {
            $task.BusinessService = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 
    if ($parameters.ContainsKey("AssignedTo")) {
        if (-not [string]::IsNullOrEmpty($AssignedTo)) {
            $task.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $task.AssignedTo = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
            
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if (-not [string]::IsNullOrEmpty($AssignmentGroup)) {
            $task.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $task.AssignmentGroup = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     
          
    if ($parameters.ContainsKey("Comments")) {
        $task.Comments = $Comments
    }

    if ($parameters.ContainsKey("WorkNotes")) {
        $task.WorkNotes = $WorkNotes
    }

    if ($parameters.ContainsKey("Urgency")) {
        $task.Urgency = $Urgency
    }   
 
    if ($parameters.ContainsKey("Impact")) {
        $task.Impact = $Impact
    }   
 
    if ($parameters.ContainsKey("State")) {
        $task.State = $State
    }   
     
    if ($parameters.ContainsKey("ShortDescription")) {
        $task.ShortDescription = $ShortDescription
    }

    if ($parameters.ContainsKey("Priority")) {
        $task.Priority = $Priority
    } 

    if ($parameters.ContainsKey("AdditionalAssigneeList")) {
        $task.AdditionalAssigneeList = $AdditionalAssigneeList
    } 
    
    if ($parameters.ContainsKey("Company")) {
        if (-not [string]::IsNullOrEmpty($Company)) {
            $task.Company = Get-ReferenceLink $Company
        }
        else {
            $task.Company = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    } 

                
    $requestBuilder.Request().UpdateAsync($task).GetAwaiter().GetResult()
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
        [string]$Group,

        [parameter(Mandatory = $false)]
        [bool]$Inherits       
    )
    $parameters = $MyInvocation.BoundParameters  
    $membership = New-Object -TypeName ServiceNow.Graph.Models.GroupHasRole

    $membership.User = Get-ReferenceLink $Group
    $membership.Role = Get-ReferenceLink $Role

    if ($parameters.ContainsKey("Inherits")) {
        $membership.Inherits = $Inherits
    }

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
