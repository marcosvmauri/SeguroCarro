CREATE TABLE REPLAY.CARRO( ID NUMBER, VALORCARRO NUMBER(9,2), MARCA VARCHAR(100));
ALTER TABLE REPLAY.CARRO
ADD CONSTRAINT PK_CARRO
    PRIMARY KEY (ID);

CREATE TABLE REPLAY.SEGURADO( ID NUMBER, NOME VARCHAR(100), CPF VARCHAR(20), IDADE NUMBER);
ALTER TABLE REPLAY.SEGURADO
ADD CONSTRAINT PK_SEGURADO
    PRIMARY KEY (ID);

CREATE REPLAY.SEGURO( ID NUMBER, PRECOSEGURO NUMBER(9,2), SEGURADOID NUMBER, CARROID NUMBER);
ALTER TABLE REPLAY.SEGURO
ADD CONSTRAINT PK_SEGURO
    PRIMARY KEY (ID);

ALTER TABLE REPLAY.SEGURO
ADD CONSTRAINT FK_SEG_SEGURADO
    FOREIGN KEY (SEGURADOID)
    REFERENCES SEGURADO (ID);
