export enum DockType {
  Inbound = 1,
  Outbound = 2,
  Both = 3,
}

export const typeOptions = [
  { label: 'Inbound', value: DockType.Inbound },
  { label: 'Outbound', value: DockType.Outbound },
  { label: 'Both', value: DockType.Both }
];
