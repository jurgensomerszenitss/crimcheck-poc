CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;

CREATE TABLE category (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    search_text tsvector NULL,
    CONSTRAINT pk_category PRIMARY KEY (id)
);

CREATE TABLE course (
    id bigint NOT NULL,
    title character varying(100) NOT NULL,
    description character varying(4000) NOT NULL,
    active_from timestamp without time zone NULL,
    active_to timestamp without time zone NULL,
    search_text tsvector NULL,
    category_id bigint NOT NULL,
    CONSTRAINT pk_course PRIMARY KEY (id),
    CONSTRAINT fk_course_category_category_id FOREIGN KEY (category_id) REFERENCES category (id) ON DELETE CASCADE
);

CREATE TABLE lesson (
    id bigint NOT NULL,
    topic character varying(500) NOT NULL,
    description character varying(4000) NOT NULL,
    search_text tsvector NULL,
    course_id bigint NOT NULL,
    CONSTRAINT pk_lesson PRIMARY KEY (id),
    CONSTRAINT fk_lesson_course_course_id FOREIGN KEY (course_id) REFERENCES course (id) ON DELETE CASCADE
);

CREATE INDEX ix_course_category_id ON course (category_id);

CREATE INDEX ix_lesson_course_id ON lesson (course_id);

CREATE FUNCTION category_update() RETURNS TRIGGER AS $$ BEGIN new.search_text:= setweight(to_tsvector(COALESCE('new.name', '')), 'A') ;
                        return new; 
 END $$ LANGUAGE plpgsql;

CREATE FUNCTION course_update() RETURNS TRIGGER AS $$ BEGIN new.search_text:= setweight(to_tsvector(COALESCE('new.title', '')), 'A') || setweight(to_tsvector(COALESCE(new.description, '')), 'B');
                        return new; 
 END $$ LANGUAGE plpgsql;

CREATE TRIGGER category_upsert_trigger BEFORE INSERT OR UPDATE ON category FOR EACH ROW EXECUTE PROCEDURE category_update();

CREATE TRIGGER course_upsert_trigger BEFORE INSERT OR UPDATE ON course FOR EACH ROW EXECUTE PROCEDURE course_update();

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20210821172718_initial', '5.0.9');

COMMIT;

