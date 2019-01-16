SELECT t_check_ms.chk_no, 
       t_check_ms.chk_method_id, 
       t_check_ms.chk_flg, 
       t_check_ms.in_1, 
       t_check_ms.in_2, 
       t_check_ms.chk_result, 
       t_check_ms.mark, 
       t_check_ms.kj_0, 
       t_check_ms.kj_1, 
       t_check_ms.kj_2, 
       t_check_ms.kj_explain, 
       t_check_ms.ins_user, 
       t_check_ms.ins_date, 
       m_temp.project_name, 
       m_temp.pic_name, 
       m_temp.chk_km_name, 
       m_temp.chk_name, 
       m_temp.tool_id, 
       m_temp.kj_0       AS kj_0_Expr, 
       m_temp.kj_1       AS kj_1_Expr, 
       m_temp.kj_2       AS kj_2_Expr, 
       m_temp.kj_explain AS kj_explain_Expr, 
       m_temp.line_id, 
       m_temp.temp_id ,
	   m_temp.chk_id ,
		m_check_method.chk_method, 
		m_check_method.chk_formula, 
		m_check_method.verify_method_explain 
FROM   t_check_ms 
       LEFT JOIN m_temp 
               ON t_check_ms.chk_method_id = m_temp.chk_method_id 
       LEFT JOIN m_check_method 
               ON m_temp.chk_id = m_check_method.chk_id 
       LEFT JOIN m_tools 
               ON m_temp.tool_id = m_tools.tool_id 
                  AND m_temp.line_id = m_tools.line_id 
WHERE
	 t_check_ms.chk_no = '190112_049010465_1'
	 AND  m_temp.line_id = 'SRM1312A'
ORDER BY m_temp.chk_method_id