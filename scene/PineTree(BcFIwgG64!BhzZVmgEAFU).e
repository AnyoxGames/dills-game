13
4114578669569
404973280063160 1761863314843894100
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 0.0275173187255859,
    "Y": -10.0048732757568359
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404970775650495:1761863314260363400",
  "next_sibling": "404974352571181:1761863315093789700",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404973280544416:1761863314844005300",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404973280697238:1761863314844040900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404973280544416:1761863314844005300",
    "DefaultRenderer": "404973280779583:1761863314844060100",
    "DepletedRenderer": "404973280751633:1761863314844053600"
  }
},
{
  "cid": 5,
  "aoid": "404973280718910:1761863314844046000",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
