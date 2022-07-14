function Get-ServiceNowClient {
    param (
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $false)]
        [ValidateNotNullOrEmpty()]
        [String]$URL,

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

        [parameter(Mandatory = $false, ValueFromPipelineByPropertyName = $false)]
        [Int]$PageSize = 1000
    )

    if ($null -eq $Global:ServiceNowClient) {
        # Initialize the client
        $plainPW = ""
        $ptr = [System.IntPtr]::Zero
        try {
            $ptr = [System.IntPtr]::Zero    
            $ptr = [System.Runtime.InteropServices.Marshal]::SecureStringToGlobalAllocUnicode($ClientSecret)
            $plainPW = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($ptr)
        }
        finally {
            [System.Runtime.InteropServices.Marshal]::ZeroFreeGlobalAllocUnicode($ptr)
        }
        Add-Type -Path $LibraryPath
        $authenticationProvider = New-Object -TypeName ServiceNow.Graph.Authentication.ApiGatewayCredentialProvider -ArgumentList $ClientId, $plainPW
        # Last parameter is the version that is mangled in the API Gateway URL
        $Global:ServiceNowClient = New-Object -TypeName ServiceNow.Graph.Requests.ServiceNowClient -ArgumentList $URL, $authenticationProvider, $null, ""
        $Global:PageSize = $PageSize
    }
}
function Remove-ServiceNowClient {
    #$Global:ServiceNowClient = $null
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Users -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
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
    
        Get-Entity -CollectionBuilder $ServiceNowClient.UserGroups -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
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
    
        Get-Entity -CollectionBuilder $ServiceNowClient.Profiles -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}    

function Get-SnowGroupMembership {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id
    )
        
   Get-Entity -CollectionBuilder $ServiceNowClient.Memberships -Id $Id

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
        
    Get-Entity -CollectionBuilder $ServiceNowClient.Tasks -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.CatalogRequests -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy     
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.CatalogTasks -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy     
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.RequestItems -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Locations -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
      
        Get-Entity -CollectionBuilder $ServiceNowClient.ServiceCatalogs -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
    Get-Entity -CollectionBuilder $ServiceNowClient.CatalogOptions -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Variables -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
    Get-Entity -CollectionBuilder $ServiceNowClient.CatalogItems -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.OrderGuides -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.VariableOwnerships -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Incidents -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
}                            
function Get-SnowAttachment {
    param (
        [parameter(Mandatory = $false)]
        [String]$Id
    )
    $collectionBuilder = $ServiceNowClient.Attachments        
    $outcome = $null
    if ($Id) {
        $outcome = $collectionBuilder[$Id].Request().GetAsync().GetAwaiter().GetResult()    
    }
    else {
        $page = $collectionBuilder.Request().Filter("table_name=ZZ_YYlive_profile").Top($Global:PageSize).GetAsync().GetAwaiter().GetResult()
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Departments -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.CostCenters -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.Companies -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.ConfigurationItems -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy    
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
  
        Get-Entity -CollectionBuilder $ServiceNowClient.Roles -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
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

    Get-Entity -CollectionBuilder $ServiceNowClient.GroupHasRoles -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.RoleHasRoles -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
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
        
        Get-Entity -CollectionBuilder $ServiceNowClient.UserHasRoles -Id $Id -Filter $Filter -Select $Select -OrderBy $OrderBy
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
            "sc_request" { $builder = $ServiceNowClient.CatalogRequests }
            "sc_req_item" {$builder = $ServiceNowClient.RequestItems}
            "sc_task" {$builder = $ServiceNowClient.CatalogTasks}
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
        $userRequestBuilder = $ServiceNowClient.Users[$Id] 
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
        [int]$Priority,

        [parameter(Mandatory = $false)]
        [string]$AdditionalAssigneeList,

        [parameter(Mandatory = $false)]
        [string]$Location

)
    
    $requestBuilder = $ServiceNowClient.CatalogTasks[$Id] 
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
    
    $requestBuilder = $ServiceNowClient.CatalogTasks
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
        
    $userRequestBuilder = $ServiceNowClient.Users[$Id] 
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
        
    $userRequestBuilder = $ServiceNowClient.Users
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
        
    $ServiceNowClient.Users[$id].DeleteAsync().GetAwaiter().GetResult() | Out-Null
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
        
    $catalogOptionsRequestBuilder = $ServiceNowClient.CatalogOptions[$Id] 
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
        
    $catalogOptionsRequestBuilder = $ServiceNowClient.CatalogOptions
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

function New-SnowVariableOwnership {
    param (
        [parameter(Mandatory = $true)]
        [string]$CatalogItemOption,

        [parameter(Mandatory = $true)]
        [string]$CatalogRequestItem

    )
        
    $variableOwnershipBuilder = $ServiceNowClient.VariableOwnerships
    $variableOwnership = New-Object -TypeName ServiceNow.Graph.Models.CatalogItemOptionMtom
            
    $variableOwnership.CatalogItemOption =  Get-ReferenceLink $CatalogItemOption
    $variableOwnership.CatalogRequestItem =  Get-ReferenceLink $CatalogRequestItem

    $variableOwnershipBuilder.Request().AddAsync($variableOwnership).GetAwaiter().GetResult()
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
        
    $groupRequestBuilder = $ServiceNowClient.UserGroups[$Id] 
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
    
    $groupRequestBuilder = $ServiceNowClient.UserGroups
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
    
    $ServiceNowClient.UserGroups[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
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
    
    $ServiceNowClient.Memberships[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
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
        [string]$WorkNotes,

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
    
    $requestItemsBuilder = $ServiceNowClient.RequestItems[$Id] 
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
    if ($parameters.ContainsKey("WorkNotes")) {
        $requestItem.WorkNotes = $WorkNotes
    }            
    if ($parameters.ContainsKey("Active")) {
        $requestItem.Active = $Active
    } 
        
    $requestItemsBuilder.Request().UpdateAsync($requestItem).GetAwaiter().GetResult()
}         

function New-SnowRequestItem {
    param (
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
        [string]$WorkNotes,

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
    
    $requestItemsBuilder = $ServiceNowClient.RequestItems
    $requestItem = New-Object -TypeName ServiceNow.Graph.Models.RequestItem
    $parameters = $MyInvocation.BoundParameters  


    $requestItem.RequestedFor = Get-ReferenceLink $RequestedFor
    $requestItem.CatalogItem = Get-ReferenceLink $CatalogItem
    $requestItem.Request = Get-ReferenceLink $Request

    if ($parameters.ContainsKey("Price")) {
        if(-not [string]::IsNullOrEmpty($Price)){
            $requestItem.Price =  $Price
        }
    } 
    if ($parameters.ContainsKey("WorkNotes")) {
        $requestItem.WorkNotes = $WorkNotes
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
        [string]$WorkNotes,

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
    
    $requestBuilder = $ServiceNowClient.CatalogRequests[$Id] 
    $request = New-Object -TypeName ServiceNow.Graph.Models.CatalogRequest
    $parameters = $MyInvocation.BoundParameters  
    $request.Id = $Id

    if ($parameters.ContainsKey("Active")) {
        $request.Active = $Active
    }
    
    if ($parameters.ContainsKey("DeliveryAddress")) {
        $request.DeliveryAddress = $DeliveryAddress
    }
    
    if ($parameters.ContainsKey("WorkNotes")) {
        $request.WorkNotes = $WorkNotes
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
        [string]$WorkNotes,

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
    
    $requestBuilder = $ServiceNowClient.CatalogRequests
    $request = New-Object -TypeName ServiceNow.Graph.Models.CatalogRequest
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("Active")) {
        $request.Active = $Active
    }

    if ($parameters.ContainsKey("DeliveryAddress")) {
        $request.DeliveryAddress = $DeliveryAddress
    }
    
    if ($parameters.ContainsKey("WorkNotes")) {
        $request.WorkNotes = $WorkNotes
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

    $requestBuilder.Request().AddAsync($request).GetAwaiter().GetResult()
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
$profileRequestBuilder = $ServiceNowClient.Profiles[$Id] 
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
    
    $profileRequestBuilder = $ServiceNowClient.Profiles
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

function Remove-SnowAttachment {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.Attachments[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
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
    
    $attachmentRequestBuilder = $ServiceNowClient.Attachments
    $attachment = New-Object -TypeName ServiceNow.Graph.Models.Attachment

    $attachment.FileName = $FileName
    $attachment.TableName = $TableName
    $attachment.TableSysId = $TableSysId
    $attachment.ContentType = $ContentType
    $attachment.Image = $Image

    $attachmentRequestBuilder.Request().AddAsync($attachment).GetAwaiter().GetResult()
}

function New-SnowIncident {
    param (
        [parameter(Mandatory = $false)]
        [bool]$Active,

        [parameter(Mandatory = $true)]
        [string]$Caller,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $true)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [int]$IncidentState,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $true)]
        [string]$ShortDescription,

        [parameter(Mandatory = $true)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $true)]
        [string]$Category,
        
        [parameter(Mandatory = $true)]
        [string]$SubCategory,
        
        [parameter(Mandatory = $false)]
        [string]$OpenedBy
    )
    
    $incidentBuilder = $ServiceNowClient.Incidents
    $incident = New-Object -TypeName ServiceNow.Graph.Models.Incident
    $parameters = $MyInvocation.BoundParameters  

    if ($parameters.ContainsKey("Active")) {
        $incident.Active = $Active
    }
    if ($parameters.ContainsKey("CloseNotes")) {
        $incident.CloseNotes = $CloseNotes
    } 
    if ($parameters.ContainsKey("Description")) {
        $incident.Description = $Description
    }         
    if ($parameters.ContainsKey("Category")) {
        $incident.Category = $Category
    }         
    if ($parameters.ContainsKey("SubCategory")) {
        $incident.SubCategory = $SubCategory
    }         

    if ($parameters.ContainsKey("AssignedTo")) {
        if (-not [string]::IsNullOrEmpty($AssignedTo)) {
            $incident.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $incident.AssignedTo = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          

    if ($parameters.ContainsKey("OpenedBy")) {
        if (-not [string]::IsNullOrEmpty($OpenedBy)) {
            $incident.OpenedBy = Get-ReferenceLink $OpenedBy
        }
        else {
            $incident.OpenedBy = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          

    if ($parameters.ContainsKey("Caller")) {
        if (-not [string]::IsNullOrEmpty($Caller)) {
            $incident.Caller = Get-ReferenceLink $Caller
        }
        else {
            $incident.Caller = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
            
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if (-not [string]::IsNullOrEmpty($AssignmentGroup)) {
            $incident.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $incident.AssignmentGroup = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     
          
    if ($parameters.ContainsKey("Comments")) {
        $incident.Comments = $Comments
    }
    if ($parameters.ContainsKey("ContactType")) {
        $incident.ContactType = $ContactType
    }    
              
    if ($parameters.ContainsKey("Location")) {
        if (-not [string]::IsNullOrEmpty($Location)) {
            $incident.Location = Get-ReferenceLink $Location
        }
        else {
            $incident.Location = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }

    if ($parameters.ContainsKey("State")) {
        $incident.State = $State
    }   
    if ($parameters.ContainsKey("IncidentState")) {
        $incident.IncidentState = $IncidentState
    }   
    if ($parameters.ContainsKey("Impact")) {
        $incident.Impact = $Impact
    }   
    if ($parameters.ContainsKey("Urgency")) {
        $incident.Urgency = $Urgency
    }   
               
    if ($parameters.ContainsKey("ShortDescription")) {
        $incident.ShortDescription = $ShortDescription
    }

    if ($parameters.ContainsKey("CmdbCi")) {
        if (-not [string]::IsNullOrEmpty($CmdbCi)) {
            $incident.CmdbCi = Get-ReferenceLink $CmdbCi
        }
        else {
            $incident.CmdbCi = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
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
        [string]$Caller,

        [parameter(Mandatory = $false)]
        [string]$AssignedTo,

        [parameter(Mandatory = $false)]
        [string]$AssignmentGroup,

        [parameter(Mandatory = $false)]
        [string]$CloseNotes,

        [parameter(Mandatory = $false)]
        [string]$Comments,

        [parameter(Mandatory = $false)]
        [string]$WorkNotes,

        [parameter(Mandatory = $false)]
        [string]$ContactType,

        [parameter(Mandatory = $false)]
        [string]$Location,

        [parameter(Mandatory = $false)]
        [int]$State,

        [parameter(Mandatory = $false)]
        [int]$IncidentState,

        [parameter(Mandatory = $false)]
        [int]$Urgency,

        [parameter(Mandatory = $false)]
        [int]$Impact,

        [parameter(Mandatory = $false)]
        [string]$ShortDescription,

        [parameter(Mandatory = $false)]
        [string]$CmdbCi,

        [parameter(Mandatory = $false)]
        [string]$Description,

        [parameter(Mandatory = $false)]
        [string]$Category,
        
        [parameter(Mandatory = $false)]
        [string]$SubCategory,

        [parameter(Mandatory = $false)]
        [string]$CloseCode
                   
    )
    
    $incidentBuilder = $ServiceNowClient.Incidents[$Id] 
    $incident = New-Object -TypeName ServiceNow.Graph.Models.Incident
    $parameters = $MyInvocation.BoundParameters  
    $incident.Id = $Id

    if ($parameters.ContainsKey("Active")) {
        $incident.Active = $Active
    }
    if ($parameters.ContainsKey("CloseNotes")) {
        $incident.CloseNotes = $CloseNotes
    } 
    if ($parameters.ContainsKey("CloseCode")) {
        $incident.CloseCode = $CloseCode
    }     
    if ($parameters.ContainsKey("Description")) {
        $incident.Description = $Description
    }         
    if ($parameters.ContainsKey("Category")) {
        $incident.Category = $Category
    }         
    if ($parameters.ContainsKey("SubCategory")) {
        $incident.SubCategory = $SubCategory
    }         

    if ($parameters.ContainsKey("AssignedTo")) {
        if (-not [string]::IsNullOrEmpty($AssignedTo)) {
            $incident.AssignedTo = Get-ReferenceLink $AssignedTo
        }
        else {
            $incident.AssignedTo = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          

    if ($parameters.ContainsKey("Caller")) {
        if (-not [string]::IsNullOrEmpty($Caller)) {
            $incident.Caller = Get-ReferenceLink $Caller
        }
        else {
            $incident.Caller = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }          
            
    if ($parameters.ContainsKey("AssignmentGroup")) {
        if (-not [string]::IsNullOrEmpty($AssignmentGroup)) {
            $incident.AssignmentGroup = Get-ReferenceLink $AssignmentGroup
        }
        else {
            $incident.AssignmentGroup = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }     
          
    if ($parameters.ContainsKey("Comments")) {
        $incident.Comments = $Comments
    }
    if ($parameters.ContainsKey("ContactType")) {
        $incident.ContactType = $ContactType
    }    
              
    if ($parameters.ContainsKey("Location")) {
        if (-not [string]::IsNullOrEmpty($Location)) {
            $incident.Location = Get-ReferenceLink $Location
        }
        else {
            $incident.Location = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }

    if ($parameters.ContainsKey("State")) {
        $incident.State = $State
    }   
    if ($parameters.ContainsKey("IncidentState")) {
        $incident.IncidentState = $IncidentState
    }   
    if ($parameters.ContainsKey("Impact")) {
        $incident.Impact = $Impact
    }   
    if ($parameters.ContainsKey("Urgency")) {
        $incident.Urgency = $Urgency
    }   
               
    if ($parameters.ContainsKey("ShortDescription")) {
        $incident.ShortDescription = $ShortDescription
    }

    if ($parameters.ContainsKey("CmdbCi")) {
        if (-not [string]::IsNullOrEmpty($CmdbCi)) {
            $incident.CmdbCi = Get-ReferenceLink $CmdbCi
        }
        else {
            $incident.CmdbCi = [ServiceNow.Graph.Models.ReferenceLink]$null
        }
    }                
    $incidentBuilder.Request().UpdateAsync($incident).GetAwaiter().GetResult()
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

    $ServiceNowClient.GroupHasRoles.Request().AddAsync($membership).GetAwaiter().GetResult()
}         

function Remove-SnowRoleHasGroup {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.GroupHasRoles[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
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
    $ServiceNowClient.UserHasRoles.Request().AddAsync($membership).GetAwaiter().GetResult()
}         

function Remove-SnowRoleHasUser {
    param (
        [parameter(Mandatory = $true)]
        [string]$Id
    )
    
    $ServiceNowClient.UserHasRoles[$id].Request().DeleteAsync().GetAwaiter().GetResult() | Out-Null
}         