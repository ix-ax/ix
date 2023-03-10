NAMESPACE MonsterData
    CLASS MonsterBase
        VAR PUBLIC
            Description : STRING;
            Id : ULINT;
            ArrayOfBytes : ARRAY[0..3] OF BYTE;
            ArrayOfDrives : ARRAY[0..3] OF DriveBase;
        END_VAR        
    END_CLASS
    CLASS Monster EXTENDS MonsterBase
        VAR PUBLIC
            DriveA : DriveBase;
        END_VAR        
    END_CLASS

    CLASS DriveBase
        VAR PUBLIC
            Position : LREAL;
            Velo : LREAL;
            Acc : LREAL;
            Dcc : LREAL;            
        END_VAR        
    END_CLASS
END_NAMESPACE