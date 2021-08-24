export interface Process {
    id:             number;
    name:           string;
    status:         string;
    serviceId:      number;
    serviceName:    string;
    category:       string;
    activity:       string;
    note:           string;
    gdprRequirement:boolean;
    sortOrder:      number;
    created?:        Date;
    lastEdited?:     Date;
    lastEditorId?:   number;
    statusUrl?:      string;
}