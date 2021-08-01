export interface Partner {
    id:            number;
    name:          string;
    status:        string;
    partner_group: string;
    type:          string;
    address:       string;
    email:         string;
    telephone:     string;
    agency:        string;
    created:       Date;
    lastEdited:    Date;
    lastEditorId:  number;
    statusUrl?:     string;
}
