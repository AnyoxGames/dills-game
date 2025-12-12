13
3083786518529
404802322234688 1761863275010543400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 6.5481810569763184,
    "Y": 9.4929962158203125
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404461908059641:1761863195693687900",
  "next_sibling": "404815411404757:1761863278060333500",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404802322601091:1761863275010627700",
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
  "aoid": "404802322754343:1761863275010663300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404802322601091:1761863275010627700",
    "DefaultRenderer": "404802322837806:1761863275010682700",
    "DepletedRenderer": "404802322808609:1761863275010675900"
  }
},
{
  "cid": 5,
  "aoid": "404802322775757:1761863275010668300",
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
