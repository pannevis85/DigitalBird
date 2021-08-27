export interface PartnerService {
    id:             number;
    status:         string;
    partnerId:      number;
    partnerName:    string;
    vendorId:       number;
    vendorName:     string;
    serviceId:      number;
    serviceName:    string;
    year:           number;
    note:           string;
    created?:        Date;
    lastEdited?:     Date;
    lastEditorId?:   number;
    statusUrl?:     string;
    gdprStatus?:    string;
    gdprStatusUrl?: string;
}
